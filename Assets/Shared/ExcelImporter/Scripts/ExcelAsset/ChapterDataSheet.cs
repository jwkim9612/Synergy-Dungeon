using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ChapterDataSheet : ScriptableObject
{
	public List<ChapterExcelData> ChapterExcelDatas;
	public Dictionary<int, ChapterData> ChapterDatas;

	public void Initialize()
	{
		InitializeChapterDatas();
	}

	private void InitializeChapterDatas()
	{
		ChapterDatas = new Dictionary<int, ChapterData>();

		foreach (var chapterExcelData in ChapterExcelDatas)
		{
			ChapterData chapterData = new ChapterData(chapterExcelData);
			ChapterDatas.Add(chapterData.Id, chapterData);
		}
	}
}
