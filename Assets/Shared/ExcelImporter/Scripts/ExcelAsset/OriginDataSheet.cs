using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class OriginDataSheet : ScriptableObject
{
	public List<OriginData> OriginDatas;

	public void Initialize()
	{
		InitializeImage();
	}

	private void InitializeImage()
	{
		foreach (var originData in OriginDatas)
		{
			originData.Image = Resources.Load<Sprite>(originData.ImagePath);
		}
	}
}
