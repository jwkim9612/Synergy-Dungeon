﻿using GameSparks.Api.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityEffectList : MonoBehaviour
{
    [SerializeField] private UIAbilityEffect uiAbilityEffect = null;
    [SerializeField] private UIAbilityEffectInfo uiAbilityEffectInfo = null;
    public List<UIAbilityEffect> uiAbilityEffectList;

    [SerializeField] private Camera cam;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!TransformService.ContainPos(transform as RectTransform, Input.mousePosition, cam))
            {
                if (uiAbilityEffectInfo.gameObject.activeSelf)
                {
                    uiAbilityEffectInfo.OnHide();
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
        List<int> removeIndexList = new List<int>();

        for (int i = 0; i < uiAbilityEffectList.Count; i++)
        {
            uiAbilityEffectList[i].UpdateAbilityEffectByWaveComplete();
            if(uiAbilityEffectList[i].IsOver())
            {
                RemoveAbilityEffectSaveData(i);
                removeIndexList.Add(i);
            }
        }

        // list의 앞에서부터 삭제하면 앞으로 땡겨지기때문에 문제가 발생한다.
        // 따라서 Reverse 함수로 역순으로 바꿔준 후 삭제.
        removeIndexList.Reverse();

        for (int i = 0; i < removeIndexList.Count; i++)
        {
            Destroy(uiAbilityEffectList[removeIndexList[i]].gameObject);
            uiAbilityEffectList.RemoveAt(removeIndexList[i]);
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
