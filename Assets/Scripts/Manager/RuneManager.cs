using GameSparks.Api.Requests;
using GameSparks.Core;
using SimpleJson2;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoSingleton<RuneManager>
{

    public delegate void OnAddRuneDelegate(int runeId);
    public OnAddRuneDelegate OnAddRune { get; set; }
    public Dictionary<int, int> ownedRunes { get; set; }
    public List<Rune> equippedRunes { get; set; }

    public void Initialize()
    {
        //RuneService.Initialize();
        InitializeEquippedRunes();
        LoadOwnedRuneData();
    }

    private void InitializeEquippedRunes()
    {
        var equippedRuneIdsSaveData = SaveManager.Instance.equippedRuneIdsSaveData;

        equippedRunes = new List<Rune>();
        for (int i = 0; i < equippedRuneIdsSaveData.Count; ++i)
        {
            int equippedRuneId = equippedRuneIdsSaveData[i];
            if (equippedRuneId != -1)
            {
                var runeDataSheet = DataBase.Instance.runeDataSheet;
                if(runeDataSheet == null)
                {
                    Debug.LogError("Error runeDataSheet is null");
                    return;
                }

                if(runeDataSheet.TryGetRuneData(equippedRuneId, out var runeData))
                {
                    Rune rune = new Rune();
                    rune.SetRune(runeData);
                    equippedRunes.Add(rune);
                }
            }
            else
            {
                equippedRunes.Add(null);
            }
        }
    }

    public void RemoveEquippedRune(int socketIndex)
    {
        if (socketIndex >= RuneService.NUMBER_OF_RUNE_SOCKETS)
            return;

        equippedRunes[socketIndex] = null;
    }

    public void SaveOwnedRunes()
    {
        new LogEventRequest()
            .SetEventKey("SaveOwnedRunes")
            .SetEventAttribute("Runes", JsonDataManager.Instance.ObjectToJson(ownedRunes))
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Success InGame Data Save !");
                }
                else
                {
                    Debug.Log("Error OwnedRune Save !");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    public void AddRune(int runeId, int amount = 1)
    {
        new LogEventRequest()
            .SetEventKey("AddRune")
            .SetEventAttribute("RuneId", runeId)
            .SetEventAttribute("Amount", amount)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    AddRuneToRuneList(runeId);
                    Debug.Log("Success Add Rune!");
                }
                else
                {
                    Debug.Log("Error Add Rune!");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    public void LoadOwnedRuneData()
    {
        new LogEventRequest()
            .SetEventKey("LoadOwnedRuneData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)response.ScriptData.GetBoolean("Result");
                    if(result)
                    {
                        GSData ownedRuneScriptData = response.ScriptData.GetGSData("OwnedRuneData");
                        //JObject ownedRuneJsonObject = JsonDataManager.Instance.LoadJson<JObject>(ownedRuneScriptData.JSON);
                        JsonObject ownedRuneJsonObject = JsonDataManager.Instance.LoadJson<JsonObject>(ownedRuneScriptData.JSON);

                        ownedRunes = new Dictionary<int, int>();
                        foreach (var ownedRunePair in ownedRuneJsonObject)
                        {
                            ownedRunes.Add(int.Parse(ownedRunePair.Key), int.Parse(ownedRunePair.Value.ToString()));
                        }
                    }
                    else
                    {
                        InitializeOwnedRuneData();
                    }
                }
                else
                {
                    Debug.Log("Error LoadOwnedRunes");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    public void AddRuneToRuneList(int runeId)
    {
        if (ownedRunes.ContainsKey(runeId))
        {
            ++ownedRunes[runeId];
        }
        else
        {
            ownedRunes.Add(runeId, 1);
        }

        Debug.Log("AddRuneToRuneList");
        OnAddRune(runeId);
        //SaveOwnedRunes();
    }

    public void SubRune(int runeId)
    {
        if(ownedRunes.ContainsKey(runeId))
        {
            if(ownedRunes[runeId] == 1)
            {
                ownedRunes.Remove(runeId);
            }
            else
            {
                --ownedRunes[runeId];
            }
        }
        else
        {
            Debug.Log("Error SubRune");
        }

        //SaveOwnedRunes();
    }

    public Rune GetEquippedRuneOfOrigin(Origin origin)
    {
        Rune rune;

        switch (origin)
        {
            case Origin.Archer:
                rune = equippedRunes[RuneService.INDEX_OF_ARCHER_SOCKET];
                break;
            case Origin.Paladin:
                rune = equippedRunes[RuneService.INDEX_OF_PALADIN_SOCKET];
                break;
            case Origin.Thief:
                rune = equippedRunes[RuneService.INDEX_OF_THIEF_SOCKET];
                break;
            case Origin.Warrior:
                rune = equippedRunes[RuneService.INDEX_OF_WARRIOR_SOCKET];
                break;
            case Origin.Wizard:
                rune = equippedRunes[RuneService.INDEX_OF_WIZARD_SOCKET];
                break;
            default:
                rune = null;
                break;
        }

        return rune;
    }

    public void InitializeOwnedRuneData()
    {
        new LogEventRequest()
            .SetEventKey("InitializeOwnedRuneData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Success Initialize OwnedRuneData !");
                    LoadOwnedRuneData();
                }
                else
                {
                    Debug.Log("Error Initialize OwnedRuneData !");
                }
            });
    }

    public void SetEquippedRune(Rune rune)
    {
        if (rune != null)
            equippedRunes[rune.runeData.SocketPosition] = rune;
        else
            Debug.LogError("Error SetEquippedRune");
    }
}
