using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using SharedService;

public class ProbabilityService
{
    public Dictionary<Tier, float> Probabilities = new Dictionary<Tier, float>();
    public List<Tier> tiers = new List<Tier>();

    public void Initialize()
    {
        InitializeProbabilities();
        InitializeTierList();

        SetProbailities(GameManager.instance.probabilityDatas[9]);
    }

    public void InitializeProbabilities()
    {
        Probabilities.Clear();

        Probabilities.Add(Tier.One, 0.0f);
        Probabilities.Add(Tier.Two, 0.0f);
        Probabilities.Add(Tier.Three, 0.0f);
        Probabilities.Add(Tier.Four, 0.0f);
        Probabilities.Add(Tier.Five, 0.0f);
    }

    public void InitializeTierList()
    {
        tiers.Clear();

        tiers.Add(Tier.One);
        tiers.Add(Tier.Two);
        tiers.Add(Tier.Three);
        tiers.Add(Tier.Four);
        tiers.Add(Tier.Five);
    }

    public void SetProbailities(ProbabilityData probabilityData)
    {
        Probabilities[Tier.One] = probabilityData.oneTier;
        Probabilities[Tier.Two] = probabilityData.twoTier;
        Probabilities[Tier.Three] = probabilityData.threeTier;
        Probabilities[Tier.Four] = probabilityData.fourTier;
        Probabilities[Tier.Five] = probabilityData.fiveTier;
    }

    public Tier GetRandomTier()
    {
        float randomProbability = SharedRandom.GetRandom();
        Debug.Log(randomProbability);
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

        Debug.Log("Error GetRandomTier");
        return Tier.None;
    }
}
