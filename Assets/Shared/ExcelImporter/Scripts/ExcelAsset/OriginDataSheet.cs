using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class OriginDataSheet : ScriptableObject
{
	public List<OriginExcelData> OriginExcelDatas;
	public Dictionary<Origin, OriginData> OriginDatas;

	public void Initialize()
	{
		InitializeOriginDatas();
	}

	private void InitializeOriginDatas()
	{
		OriginDatas = new Dictionary<Origin, OriginData>();

		foreach (var originExcelData in OriginExcelDatas)
		{
			OriginData originData = new OriginData(originExcelData);
			OriginDatas.Add(originData.Origin, originData);
		}
	}
}
