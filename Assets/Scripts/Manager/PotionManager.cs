using GameSparks.Api.Requests;
using GameSparks.Core;
using LitJson;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoSingleton<PotionManager>
{
    public int potionIdInUse;

    public void Initialize()
    {
        LoadPotionData();
    }

    public void LoadPotionData()
    {
        new LogEventRequest()
            .SetEventKey("LoadPotionData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)response.ScriptData.GetBoolean("Result");
                    if (result)
                    {
                        potionIdInUse = (int)response.ScriptData.GetInt("PotionIdInUse");
                    }
                    else
                    {
                        Debug.Log("Load Potion Data Result is False!!");
                        InitializePotionData();
                    }
                }
                else
                {
                    Debug.Log("Error LoadPotionData");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    private void InitializePotionData()
    {
        new LogEventRequest()
            .SetEventKey("InitializePotionData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Success Initialize PotionData !");
                    LoadPotionData();
                }
                else
                {
                    Debug.Log("Error Initialize PotionData !");
                }
            });
    }

    public bool HasPotionInUse()
    {
        if(potionIdInUse == -1)
            return false;

        return true;
    }
}
