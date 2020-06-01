using GameSparks.Api.Requests;
using GameSparks.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoSingleton<RuneManager>
{

    public delegate void OnAddRuneDelegate(int runeId);
    public OnAddRuneDelegate OnAddRune { get; set; }
    public Dictionary<int, int> ownedRunes { get; set; }
    public List<UIEquipRune> uiEquippedRunes { get; set; }

    public void Initialize()
    {
        uiEquippedRunes = new List<UIEquipRune>();
        LoadOwnedRuneData();
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
                        JObject ownedRuneJsonObject = JsonDataManager.Instance.LoadJson<JObject>(ownedRuneScriptData.JSON);

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
                rune = uiEquippedRunes[RuneService.INDEX_OF_ARCHER_SOCKET].rune;
                break;
            case Origin.Paladin:
                rune = uiEquippedRunes[RuneService.INDEX_OF_PALADIN_SOCKET].rune;
                break;
            case Origin.Thief:
                rune = uiEquippedRunes[RuneService.INDEX_OF_THIEF_SOCKET].rune;
                break;
            case Origin.Warrior:
                rune = uiEquippedRunes[RuneService.INDEX_OF_WARRIOR_SOCKET].rune;
                break;
            case Origin.Wizard:
                rune = uiEquippedRunes[RuneService.INDEX_OF_WIZARD_SOCKET].rune;
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
}
