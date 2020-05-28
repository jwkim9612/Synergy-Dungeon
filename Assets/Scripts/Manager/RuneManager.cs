using GameSparks.Api.Requests;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoSingleton<RuneManager>
{
    public Dictionary<int, int> ownedRunes;
    public List<UIEquipRune> uiEquippedRunes { get; set; }

    public void Initialize()
    {
        uiEquippedRunes = new List<UIEquipRune>();
        LoadOwnedRunes();
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

    public void LoadOwnedRunes()
    {
        new LogEventRequest()
            .SetEventKey("LoadOwnedRunes")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)response.ScriptData.GetBoolean("Result");
                    if(result)
                    {
                        ownedRunes = JsonConvert.DeserializeObject<Dictionary<int, int>>(response.ScriptData.GetString("OwnedRunes"));
                        Debug.Log("Rune데이터 있음");
                    }
                    else
                    {
                        Debug.Log("Rune데이터 없음");
                        ownedRunes = new Dictionary<int, int>();
                    }
                }
                else
                {
                    Debug.Log("Error LoadOwnedRunes");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    public void AddRune(int runeId)
    {
        if (ownedRunes.ContainsKey(runeId))
        {
            ++ownedRunes[runeId];
        }
        else
        {
            ownedRunes.Add(runeId, 1);
        }

        SaveOwnedRunes();
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

        SaveOwnedRunes();
    }

    public Rune GetEquippedRuneOfOrigin(Origin origin)
    {
        Rune rune;

        switch (origin)
        {
            case Origin.Archer:
                rune = uiEquippedRunes[0].rune;
                break;
            case Origin.Paladin:
                rune = uiEquippedRunes[1].rune;
                break;
            case Origin.Thief:
                rune = uiEquippedRunes[2].rune;
                break;
            case Origin.Warrior:
                rune = uiEquippedRunes[3].rune;
                break;
            case Origin.Wizard:
                rune = uiEquippedRunes[4].rune;
                break;
            default:
                rune = null;
                break;
        }

        return rune;
    }
}
