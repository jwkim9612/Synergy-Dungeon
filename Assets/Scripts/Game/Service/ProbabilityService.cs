using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using Shared.Service;

public class ProbabilityService
{
    //public Dictionary<Tier, float> Probabilities { get; set; }
    public Dictionary<Tier, long> Probabilities { get; set; }
    public List<Tier> tiers { get; set; }

    public ProbabilityService()
    {
        Probabilities = new Dictionary<Tier, long>();
        tiers = new List<Tier>();
    }

    public void Initialize()
    {
        InitializeProbabilities();
        InitializeTierList();

        UpdateProbability();

        InGameManager.instance.playerState.OnLevelUp += UpdateProbability;
    }

    public void UpdateProbability()
    {
        var probabilityData = GameManager.instance.dataSheet.probabilityDataSheet.ProbabilityDatas[InGameManager.instance.playerState.level];
       
        SetProbabilities(probabilityData);
    }

    public void InitializeProbabilities()
    {
        Probabilities.Clear();

        Probabilities.Add(Tier.One, 0);
        Probabilities.Add(Tier.Two, 0);
        Probabilities.Add(Tier.Three, 0);
        Probabilities.Add(Tier.Four, 0);
    }

    public void InitializeTierList()
    {
        tiers.Clear();

        tiers.Add(Tier.One);
        tiers.Add(Tier.Two);
        tiers.Add(Tier.Three);
        tiers.Add(Tier.Four);
    }

    public void SetProbabilities(ProbabilityData probabilityData)
    {
        Probabilities[Tier.One] = probabilityData.OneTier;
        Probabilities[Tier.Two] = probabilityData.TwoTier;
        Probabilities[Tier.Three] = probabilityData.ThreeTier;
        Probabilities[Tier.Four] = probabilityData.FourTier;
    }

    public Tier GetRandomTier()
    {
        long randomProbability = RandomService.GetRandomLong();
        long comparisonValue = 0;

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
