using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RunePurchaseableLevelDataSheet : ScriptableObject
{
	public List<RunePurchaseableLevelExcelData> RunePurchaseableLevelExcelDatas;
    public Dictionary<int, RunePurchaseableLevelData> RunePurchaseableLevelDatas;

	public void Initialize()
	{
		InitializeRunePurchaseableLevelDatas();
	}

	private void InitializeRunePurchaseableLevelDatas()
	{
		RunePurchaseableLevelDatas = new Dictionary<int, RunePurchaseableLevelData>();

		foreach (var runePurchaseableLevelExcelData in RunePurchaseableLevelExcelDatas)
		{
			RunePurchaseableLevelData runePurchaseableLevelData = new RunePurchaseableLevelData(runePurchaseableLevelExcelData);
			RunePurchaseableLevelDatas.Add(runePurchaseableLevelData.SalesIndex, runePurchaseableLevelData);
		}
	}
}
