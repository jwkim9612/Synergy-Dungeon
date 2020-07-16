using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEffect
{
    public Ability ability;
    public int remainingTurn;
    private WayOfCalculate wayOfCalculate;
    public int effectValue;
    public string description;

    public AbilityEffectData abilityEffectData;
    public List<int> dataIdList;

    public AbilityEffect(PotionData potionData)
    {
        ability = potionData.Ability;
        remainingTurn = -1;
        wayOfCalculate = potionData.WayOfIncrease;
        effectValue = potionData.IncreaseValue;
        abilityEffectData = AbilityEffectData.Potion;
        description = potionData.Description;

        dataIdList = new List<int>(); 
        dataIdList.Add(potionData.Id);
    }

    public AbilityEffect(ScenarioData scenarioData)
    {
        ability = scenarioData.ApplyAbility;
        remainingTurn = scenarioData.ApplyTurn;
        wayOfCalculate = WayOfCalculate.Percentage;
        effectValue = scenarioData.ApplyPercentage;
        abilityEffectData = AbilityEffectData.Scenario;
        description = scenarioData.RewardDescription;

        dataIdList = new List<int>();
        dataIdList.Add(scenarioData.ChapterId);
        dataIdList.Add(scenarioData.WaveId);
        dataIdList.Add(scenarioData.ScenarioId);
    }

    public void DecreaseRemainingTurn()
    {
        if(remainingTurn != -1)
        {
            --remainingTurn;
        }
    }

    public bool IsOver()
    {
        if (remainingTurn == 0)
            return true;

        return false;
    }

    //public void SetabilityEffect(PotionData potionData)
    //{
    //    ability = potionData.Ability;
    //    remainingTurn = -1;
    //}

    //public void SetabilityEffect(ScenarioData scenarioData)
    //{
    //    ability = scenarioData.ApplyAbility;
    //    remainingTurn = scenarioData.ApplyTurn;
    //}
}
