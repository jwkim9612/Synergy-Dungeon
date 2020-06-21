using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class TribeDataSheet : ScriptableObject
{
	public List<TribeExcelData> TribeExcelDatas;
	private Dictionary<Tribe, TribeData> TribeDatas;

	public bool TryGetTribeData(Tribe tribe, out TribeData tribeData)
	{
		tribeData = new TribeData(TribeDatas[tribe]);
		if (tribeData != null)
		{
			return true;
		}

		Debug.LogError("Error TryGetTribeData");
		return false;
	}

	public bool TryGetTribeDatas(out Dictionary<Tribe, TribeData> tribeDatas)
	{
		tribeDatas = new Dictionary<Tribe, TribeData>(TribeDatas);
		if (tribeDatas != null)
		{
			return true;
		}

		Debug.LogError("Error TryGetTribeDatas");
		return false;
	}


	public bool TryGetTribeImage(Tribe tribe, out Sprite sprite)
	{
		sprite = null;

		if (TribeDatas.TryGetValue(tribe, out var tribeData))
		{
			sprite = tribeData.Image;
			return true;
		}

		Debug.LogError("Error TryGetTribeImage");
		return false;
	}

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
			TribeDatas.Add(tribeData.Tribe, tribeData);
		}
	}
}