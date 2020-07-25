using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class InGameExpDataSheet : ScriptableObject
{
	public List<InGameExpExcelData> InGameExpExcelDatas;
    private Dictionary<int, InGameExpData> InGameExpDatas;

    public bool TryGetInGameExpData(int level, out InGameExpData data)
    {
        data = null;

        if (InGameExpDatas.TryGetValue(level, out var inGameExpData))
        {
            data = new InGameExpData(inGameExpData);
            return true;
        }

        Debug.LogError($"Error TryGetInGameExpData level:{level}");
        return false;
    }

    public bool TryGetSatisfyExp(int level, out int satisfyExp)
    {
        satisfyExp = 0;

        if(TryGetInGameExpData(level, out var inGameExpData))
        {
            satisfyExp = inGameExpData.SatisfyExp;
            return true;
        }

        Debug.LogError($"Error TryGetSatisfyExp level:{level}");
        return false;
    }

    public void Initialize()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        InGameExpDatas = new Dictionary<int, InGameExpData>();

        foreach (var inGameExpExcelData in InGameExpExcelDatas)
        {
            InGameExpData inGameExpData = new InGameExpData(inGameExpExcelData);
            InGameExpDatas.Add(inGameExpData.Level, inGameExpData);
        }
    }
}
