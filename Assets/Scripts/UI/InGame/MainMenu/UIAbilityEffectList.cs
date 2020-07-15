using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilityEffectList : MonoBehaviour
{
    [SerializeField] private UIAbilityEffect uiAbilityEffect = null;
    public List<UIAbilityEffect> uiAbilityEffectList;

    private void Start()
    {
        InGameManager.instance.gameState.OnComplete += UpdateabilityEffectList;

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
                    AddabilityEffect(potionData);
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
                        AddabilityEffect(potionData);
                    }
                    break;

                case AbilityEffectData.Scenario:

                    int chapterId = abilityEffectSaveData.DataIdList[0];
                    int waveId = abilityEffectSaveData.DataIdList[1];
                    int scenarioId = abilityEffectSaveData.DataIdList[2];
                    
                    if (DataBase.Instance.inGameEvent_ScenarioDataSheet.TryGetScenarioData(chapterId, waveId, scenarioId, out var scenarioData))
                    {
                        var abilityEffect = AddabilityEffect(scenarioData);
                        abilityEffect.remainingTurn = abilityEffectSaveData.remainingTurn;
                    }

                    break;
                default:
                    break;
            }
        }
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

    public void AddabilityEffect(PotionData potionData)
    {
        var uiabilityEffect = Instantiate(this.uiAbilityEffect, transform);
        uiabilityEffect.SetabilityEffect(potionData);
        uiabilityEffect.OnShow();

        uiAbilityEffectList.Add(uiabilityEffect);
    }

    public AbilityEffect AddabilityEffect(ScenarioData scenarioData)
    {
        var uiabilityEffect = Instantiate(this.uiAbilityEffect, transform);
        var abilityEffect = uiabilityEffect.SetabilityEffect(scenarioData);
        uiabilityEffect.OnShow();

        uiAbilityEffectList.Add(uiabilityEffect);

        return abilityEffect;
    }

    private void UpdateabilityEffectList()
    {
        foreach (var uiabilityEffect in uiAbilityEffectList)
        {
            uiabilityEffect.UpdateabilityEffect();
            if(uiabilityEffect.IsOver())
            {
                uiabilityEffect.Destroy();
            }
        }
    }
}
