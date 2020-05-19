using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class CharacterDataSheet : ScriptableObject
{
	public List<CharacterData> characterDatas; // Replace 'EntityType' to an actual type that is serializable.

	public void Initialize()
	{
		InitializeImage();
		InitializeOriginData();
		InitializeTribeData();
	}

	private void InitializeImage()
	{
		foreach (var characterData in characterDatas)
		{
			characterData.Image = Resources.Load<Sprite>(characterData.ImagePath);
		}
	}

	private void InitializeOriginData()
	{
		foreach (var characterData in characterDatas)
		{
			foreach(var originData in GameManager.instance.dataSheet.originDataSheet.OriginDatas)
			{
				if(originData.Name == characterData.Origin)
				{
					characterData.OriginData = originData;
					break;
				}
			}
		}
	}

	private void InitializeTribeData()
	{
		foreach (var characterData in characterDatas)
		{
			foreach (var tribeData in GameManager.instance.dataSheet.tribeDataSheet.TribeDatas)
			{
				if (tribeData.Name == characterData.Tribe)
				{
					characterData.TribeData = tribeData;
					break;
				}
			}
		}
	}
}
