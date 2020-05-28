using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RuneDataSheet : ScriptableObject
{
	public List<RuneExcelData> RuneExcelDatas;
    public Dictionary<int, RuneData> RuneDatas;

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
