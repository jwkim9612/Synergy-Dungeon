using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ProbabilityDataSheet : ScriptableObject
{
	public List<ProbabilityExcelData> ProbabilityExcelDatas;
    public Dictionary<int, ProbabilityData> ProbabilityDatas;

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
