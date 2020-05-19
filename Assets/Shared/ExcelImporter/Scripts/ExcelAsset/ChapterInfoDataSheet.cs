using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ChapterInfoDataSheet : ScriptableObject
{
	public List<ChapterInfoData> ChapterInfoDatas;

	public void Initialize()
	{
		InitializeMonsterIds();
		InitializeFrontIds();
		InitializeBackIds();
	}

	private void InitializeMonsterIds()
	{
		foreach (var ChapterInfoData in ChapterInfoDatas)
		{
			ChapterInfoData.MonsterIdList.Clear();

			string[] monsterIdsStr = ChapterInfoData.MonsterIds.Split(',');
			foreach (var monsterId in monsterIdsStr)
			{
				ChapterInfoData.MonsterIdList.Add(monsterId[0] - '0');
			}
		}
	}

	private void InitializeFrontIds()
	{
		foreach (var ChapterInfoData in ChapterInfoDatas)
		{
			ChapterInfoData.FrontIdList.Clear();

			if (ChapterInfoData.FrontIds == "")
				continue;

			string[] frontIdsStr = ChapterInfoData.FrontIds.Split(',');
			foreach (var frontId in frontIdsStr)
			{
				ChapterInfoData.FrontIdList.Add(frontId[0] - '0');
			}
		}
	}

	private void InitializeBackIds()
	{
		foreach (var ChapterInfoData in ChapterInfoDatas)
		{
			ChapterInfoData.BackIdList.Clear();

			if (ChapterInfoData.BackIds == "")
				continue;

			string[] backIdsStr = ChapterInfoData.BackIds.Split(',');
			foreach (var backId in backIdsStr)
			{
				ChapterInfoData.BackIdList.Add(backId[0] - '0');
			}
		}
	}
}
