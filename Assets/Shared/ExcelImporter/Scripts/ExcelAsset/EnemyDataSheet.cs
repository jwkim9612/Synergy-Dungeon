using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class EnemyDataSheet : ScriptableObject
{
    public List<EnemyData> EnemyDatas;

	public void Initialize()
	{
		InitializeImage();
	}

	private void InitializeImage()
	{
		foreach (var enemyData in EnemyDatas)
		{
			enemyData.Image = Resources.Load<Sprite>(enemyData.ImagePath);
		}
	}
}
