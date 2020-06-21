using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class OriginDataSheet : ScriptableObject
{
	public List<OriginExcelData> OriginExcelDatas;
	private Dictionary<Origin, OriginData> OriginDatas;

	public bool TryGetOriginData(Origin origin, out OriginData originData)
	{
		originData = new OriginData(OriginDatas[origin]);
		if (originData != null)
		{
			return true;
		}

		Debug.LogError("Error TryGetOriginData");
		return false;
	}

	public bool TryGetOriginDatas(out Dictionary<Origin, OriginData> originDatas)
	{
		originDatas = new Dictionary<Origin, OriginData>(OriginDatas);
		if(originDatas != null)
		{
			return true;
		}

		Debug.LogError("Error TryGetOriginDatas");
		return false;
	}


	public bool TryGetOriginImage(Origin origin, out Sprite sprite)
	{
		sprite = null;

		if(OriginDatas.TryGetValue(origin, out var originData))
		{
			sprite = originData.Image;
			return true;
		}

		Debug.LogError("Error TryGetOriginImage");
		return false;
	}

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
