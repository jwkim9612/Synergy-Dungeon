using GameSparks.Api.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityEffectList : MonoBehaviour
{
    [SerializeField] private UIAbilityEffect uiAbilityEffect = null;
    public List<UIAbilityEffect> uiAbilityEffectList;

    private void Start()
    {
        InGameManager.instance.gameState.OnComplete += UpdateAbilityEffectListByWaveComplete;

        uiAbilityEffectList = new List<UIAbilityEffect>();

        if (SaveManager.Instance.IsLoadedData)
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.AbilityEffectSaveDataList);
        }
        else
        {
            if(PotionManager.Instance.HasPotionInUse())
            {
                if(DataBase.Instance.potionDataSheet.TryGetPotionData(PotionManager.Instance.potionIdInUse, out var potionData))
                {
                    AddAbilityEffect(potionData);
                    PotionManager.Instance.RemovePotionData();
                }
            }
        }

    }

    public void InitializeByInGameSaveData(List<AbilityEffectSaveData> abilityEffectSaveDataList)
    {
        foreach (var abilityEffectSaveData in abilityEffectSaveDataList)
        {
            switch (abilityEffectSaveData.abilityEffectData)
            {
                case AbilityEffectData.None:
                    break;
                case AbilityEffectData.Potion:
                    
                    if(DataBase.Instance.potionDataSheet.TryGetPotionData(abilityEffectSaveData.DataIdList[0], out var potionData))
                    {
                        AddAbilityEffect(potionData);
                    }
                    break;

                case AbilityEffectData.Scenario:

                    int chapterId = abilityEffectSaveData.DataIdList[0];
                    int waveId = abilityEffectSaveData.DataIdList[1];
                    int scenarioId = abilityEffectSaveData.DataIdList[2];
                    
                    if (DataBase.Instance.inGameEvent_ScenarioDataSheet.TryGetScenarioData(chapterId, waveId, scenarioId, out var scenarioData))
                    {
                        var abilityEffect = AddAbilityEffect(scenarioData);
                        abilityEffect.remainingTurn = abilityEffectSaveData.remainingTurn;
                    }

                    break;
                default:
                    break;
            }
        }

        UpdateAbilityEffectList();
    }

    public List<AbilityEffectSaveData> GetSaveData()
    {
        Debug.Log("GetSaveData");

        List<AbilityEffectSaveData> abilityEffectSaveDataList = new List<AbilityEffectSaveData>();

        foreach (var uiabilityEffect in uiAbilityEffectList)
        {
            var dataIdList = uiabilityEffect.abilityEffect.dataIdList;
            var abilityEffectData = uiabilityEffect.abilityEffect.abilityEffectData;
            var remainingTurn = uiabilityEffect.abilityEffect.remainingTurn;

            var abilityEffectSaveData = new AbilityEffectSaveData(dataIdList, abilityEffectData, remainingTurn);
            abilityEffectSaveDataList.Add(abilityEffectSaveData);
        }

        return abilityEffectSaveDataList;
    }

    public void AddAbilityEffect(PotionData potionData)
    {
        var uiabilityEffect = Instantiate(this.uiAbilityEffect, transform);
        uiabilityEffect.SetabilityEffect(potionData);
        uiabilityEffect.OnShow();

        uiAbilityEffectList.Add(uiabilityEffect);
    }

    public AbilityEffect AddAbilityEffect(ScenarioData scenarioData)
    {
        var uiabilityEffect = Instantiate(this.uiAbilityEffect, transform);
        var abilityEffect = uiabilityEffect.SetabilityEffect(scenarioData);
        uiabilityEffect.OnShow();

        uiAbilityEffectList.Add(uiabilityEffect);

        return abilityEffect;
    }

    private void UpdateAbilityEffectListByWaveComplete()
    {
        //foreach (var uiAbilityEffect in uiAbilityEffectList)
        //{
        //    uiAbilityEffect.UpdateAbilityEffectByWaveComplete();
        //    if(uiAbilityEffect.IsOver())
        //    {
        //        Destroy(uiAbilityEffect.gameObject);
        //    }
        //}

        for (int i = 0; i < uiAbilityEffectList.Count; i++)
        {
            uiAbilityEffectList[i].UpdateAbilityEffectByWaveComplete();
            if(uiAbilityEffectList[i].IsOver())
            {
                RemoveAbilityEffectSaveData(i);
                Destroy(uiAbilityEffectList[i].gameObject);
            }
        }
    }

    private void UpdateAbilityEffectList()
    {
        foreach (var uiAbilityEffect in uiAbilityEffectList)
        {
            uiAbilityEffect.UpdateAbilityEffect();
        }
    }

    private void RemoveAbilityEffectSaveData(int index)
    {
        new LogEventRequest()
            .SetEventKey("RemoveAbilityEffectSaveData")
            .SetEventAttribute("Index", index)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Index = " + index);
                    Debug.Log("Success RemoveAbilityEffectSaveData!");
                }
                else
                {
                    Debug.Log("Error RemoveAbilityEffectSaveData!");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }
}
