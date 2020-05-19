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
		InitializeEnemyIds();
		InitializeFrontIds();
		InitializeBackIds();
	}

	private void InitializeEnemyIds()
	{
		foreach (var ChapterInfoData in ChapterInfoDatas)
		{
			ChapterInfoData.EnemyIdList.Clear();

			string[] enemyIdsStr = ChapterInfoData.EnemyIds.Split(',');
			foreach (var enemyId in enemyIdsStr)
			{
				ChapterInfoData.EnemyIdList.Add(enemyId[0] - '0');
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
