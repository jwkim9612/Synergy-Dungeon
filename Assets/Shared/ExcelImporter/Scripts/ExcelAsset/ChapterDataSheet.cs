using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ChapterDataSheet : ScriptableObject
{
	public List<ChapterData> ChapterDatas;

	public void Initialize()
	{
		InitializeImage();
		InitializeChaprterInfoData();
	}

	private void InitializeImage()
	{
		foreach (var chapterData in ChapterDatas)
		{
			chapterData.Image = Resources.Load<Sprite>(chapterData.ImagePath);
		}
	}

	private void InitializeChaprterInfoData()
	{
		foreach (var chapterData in ChapterDatas)
		{
			// �Ŀ� �����ؾ���. 
			chapterData.chapterInfoDataList = GameManager.instance.dataSheet.chapterInfoDataSheet.ChapterInfoDatas;
		}
	}
}
