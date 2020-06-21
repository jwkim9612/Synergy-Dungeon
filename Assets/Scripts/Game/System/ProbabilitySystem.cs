﻿using Shared.Service;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitySystem
{
    //public Dictionary<Tier, float> Probabilities { get; set; }
    public Dictionary<Tier, long> Probabilities { get; set; }
    public List<Tier> tiers { get; set; }

    public ProbabilitySystem()
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
        var probabilityDataSheet = DataBase.Instance.probabilityDataSheet;
        if (probabilityDataSheet == null)
        {
            Debug.LogError("Error probabilityDataSheet is null");
            return;
        }

        int playerLevel = InGameManager.instance.playerState.level;
        if (probabilityDataSheet.TryGetProbabilityData(playerLevel, out var probabilityData))
        {
            SetProbabilities(probabilityData);
        }
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
