using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ProbabilityDataSheet : ScriptableObject
{
	public List<ProbabilityExcelData> ProbabilityExcelDatas;
    private Dictionary<int, ProbabilityData> ProbabilityDatas;

    public bool TryGetProbabilityData(int level, out ProbabilityData data)
    {
        data = null;

        if (ProbabilityDatas.TryGetValue(level, out var probabilityData))
        {
            data = new ProbabilityData(probabilityData);
            return true;
        }

        Debug.LogError($"Error TryGetProbabilityData level:{level}");
        return false;
    }

    public void Initialize()
    {
        InitializeProbabilityDatasDatas();
    }

    private void InitializeProbabilityDatasDatas()
    {
        ProbabilityDatas = new Dictionary<int, ProbabilityData>();

        foreach (var probabilityExcelData in ProbabilityExcelDatas)
        {
            ProbabilityData probabilityData = new ProbabilityData(probabilityExcelData);
            ProbabilityDatas.Add(probabilityData.Level, probabilityData);
        }
    }
}
