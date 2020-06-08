using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class EnemyDataSheet : ScriptableObject
{
    public List<EnemyExcelData> EnemyExcelDatas;
	public Dictionary<int, EnemyData> EnemyDatas;

	public void Initialize()
	{
		InitializeEnemyDatas();
	}

	private void InitializeEnemyDatas()
	{
		EnemyDatas = new Dictionary<int, EnemyData>();

		foreach (var enemyExcelData in EnemyExcelDatas)
		{
			EnemyData enemyData = new EnemyData(enemyExcelData);
			EnemyDatas.Add(enemyData.Id, enemyData);
		}
	}
}
