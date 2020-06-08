using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class TribeDataSheet : ScriptableObject
{
	public List<TribeExcelData> TribeExcelDatas;
	public Dictionary<Tribe, TribeData> TribeDatas;

	public void Initialize()
	{
		InitializeTribeDatas();
	}

	private void InitializeTribeDatas()
	{
		TribeDatas = new Dictionary<Tribe, TribeData>();

		foreach (var tribeExcelData in TribeExcelDatas)
		{
			TribeData tribeData = new TribeData(tribeExcelData);
			TribeDatas.Add(tribeData.Name, tribeData);
		}
	}
}
