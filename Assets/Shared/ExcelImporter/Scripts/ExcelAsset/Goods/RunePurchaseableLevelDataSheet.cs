using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RunePurchaseableLevelDataSheet : ScriptableObject
{
	public List<RunePurchaseableLevelExcelData> RunePurchaseableLevelExcelDatas;
    private Dictionary<int, RunePurchaseableLevelData> RunePurchaseableLevelDatas;

	public bool TryGetRunePurchaseableLevel(int salesId, out int level)
	{
		level = 0;

		if (TryGetRunePurchaseableLevelData(salesId, out var runePurchaseableLevelData))
		{
			level = runePurchaseableLevelData.PurchaseableLevel;
			return true;
		}

		Debug.LogError($"Error TryGetRunePurchaseableLevel salesId:{salesId}");
		return false;
	}

	public bool TryGetRunePurchaseableLevelDatas(out Dictionary<int, RunePurchaseableLevelData> runePurchaseableLevelDatas)
	{
		runePurchaseableLevelDatas = new Dictionary<int, RunePurchaseableLevelData>(RunePurchaseableLevelDatas);
		if(runePurchaseableLevelDatas != null)
		{
			return true;
		}

		Debug.LogError("Error TryGetRunePurchaseableLevelDatas");
		return false;
	}

	public bool TryGetRunePurchaseableLevelData(int salesId, out RunePurchaseableLevelData data)
	{
		data = null;

		if(RunePurchaseableLevelDatas.TryGetValue(salesId, out var runePurchaseableLevelData))
		{
			data = new RunePurchaseableLevelData(runePurchaseableLevelData);
			return true;
		}

		Debug.LogError($"Error TryGetRunePurchaseableLevelData salesId:{salesId}");
		return false;
	}

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
			RunePurchaseableLevelDatas.Add(runePurchaseableLevelData.SalesId, runePurchaseableLevelData);
		}
	}
}
