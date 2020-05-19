using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using Shared.Service;

public class ProbabilityService
{
    public Dictionary<Tier, float> Probabilities { get; set; }
    public List<Tier> tiers { get; set; }

    public ProbabilityService()
    {
        Probabilities = new Dictionary<Tier, float>();
        tiers = new List<Tier>();
    }

    public void Initialize()
    {
        InitializeProbabilities();
        InitializeTierList();

        UpdateProbability();
    }

    public void UpdateProbability()
    {
        float relativePercentageByStage = StageManager.Instance.GetRelativePercentageByStage();
        float comparisonValue = 0.0f;
        var probabilityDatas = GameManager.instance.dataSheet.probabilityDataSheet.ProbabilityDatas;

        foreach (var probabilityData in probabilityDatas)
        {
            //comparisonValue += probabilityData.relativePercentageByStage;
            comparisonValue = 1.0f;
            // 원래 확률 정해주던거.


            if (relativePercentageByStage <= comparisonValue)
            {
                SetProbabilities(probabilityData);
                return;
            }
        }

        Debug.LogWarning("Error UpdateProbability");
    }

    public void InitializeProbabilities()
    {
        Probabilities.Clear();

        Probabilities.Add(Tier.One, 0.0f);
        Probabilities.Add(Tier.Two, 0.0f);
        Probabilities.Add(Tier.Three, 0.0f);
        Probabilities.Add(Tier.Four, 0.0f);
       // Probabilities.Add(Tier.Five, 0.0f);
    }

    public void InitializeTierList()
    {
        tiers.Clear();

        tiers.Add(Tier.One);
        tiers.Add(Tier.Two);
        tiers.Add(Tier.Three);
        tiers.Add(Tier.Four);
        //tiers.Add(Tier.Five);
    }

    public void SetProbabilities(ProbabilityData probabilityData)
    {
        Probabilities[Tier.One] = probabilityData.OneTier;
        Probabilities[Tier.Two] = probabilityData.TwoTier;
        Probabilities[Tier.Three] = probabilityData.ThreeTier;
        Probabilities[Tier.Four] = probabilityData.FourTier;
        //Probabilities[Tier.Five] = probabilityData.fiveTier;
    }

    public Tier GetRandomTier()
    {
        float randomProbability = RandomService.GetRandom();
        //Debug.Log(randomProbability);
        float comparisonValue = 0.0f;

        foreach(var tier in tiers)
        {
            if(Probabilities[tier] == 0)
            {
                continue;
            }

            comparisonValue += Probabilities[tier];

            if (randomProbability <= comparisonValue)
            {
                return tier;
            }
        }

        Debug.LogWarning("Error GetRandomTier");
        return Tier.None;
    }
}
