using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class TribeDataSheet : ScriptableObject
{
	public List<TribeData> TribeDatas;

	public void Initialize()
	{
		InitializeImage();
	}

	private void InitializeImage()
	{
		foreach (var tribeData in TribeDatas)
		{
			tribeData.Image = Resources.Load<Sprite>(tribeData.ImagePath);
		}
	}
}
