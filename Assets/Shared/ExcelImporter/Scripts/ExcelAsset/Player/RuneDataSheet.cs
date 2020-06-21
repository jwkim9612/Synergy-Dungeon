using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RuneDataSheet : ScriptableObject
{
	public List<RuneExcelData> RuneExcelDatas;
    private Dictionary<int, RuneData> RuneDatas;

    public bool TryGetRuneDatas(out Dictionary<int, RuneData> runeDatas)
    {
        runeDatas = new Dictionary<int, RuneData>(RuneDatas);
        if(runeDatas != null)
        {
            return true;
        }

        Debug.LogError("Error TryGetRuneDatas");
        return false;
    }

    public bool TryGetRuneData(int runeId, out RuneData data)
    {
        data = null;

        if(RuneDatas.TryGetValue(runeId, out var runeData))
        {
            data = new RuneData(runeData);
            return true;
        }

        Debug.LogError($"Error TryGetRuneData runeId:{runeId}");
        return false;
    }

    public void Initialize()
    {
        InitializeRuneDatas();
    }

    private void InitializeRuneDatas()
    {
        RuneDatas = new Dictionary<int, RuneData>();

        foreach (var runeExcelData in RuneExcelDatas)
        {
            RuneData runeData = new RuneData(runeExcelData);
            RuneDatas.Add(runeData.Id, runeData);
        }
    }
}
