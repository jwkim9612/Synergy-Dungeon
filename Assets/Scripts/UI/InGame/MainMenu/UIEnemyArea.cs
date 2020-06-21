﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    public UIEnemyPlacementArea frontArea;
    public UIEnemyPlacementArea backArea;

    void Start()
    {
        InGameManager.instance.gameState.OnBattle += InitializeEnemyPositions;
        InGameManager.instance.gameState.OnPrepare += CreateEnemies;

        frontArea.Initialize();
        backArea.Initialize();
    }

    public void CreateEnemies()
    {
        var currentWaveData = StageManager.Instance.currentChapterData.chapterInfoDatas[StageManager.Instance.currentWave];
        var frontIdList = currentWaveData.FrontIdList;
        var backIdList = currentWaveData.BackIdList;

        var enemyDataSheet = DataBase.Instance.enemyDataSheet;
        if (enemyDataSheet == null)
        {
            Debug.LogError("Error enemyDataSheet is null");
            return;
        }

        int currentEnemyIndex = 0;

        if (frontIdList != null)
        {
            for (int frontIndex = 0; frontIndex < frontIdList.Count; ++frontIndex)
            {
                int enemyId = currentWaveData.EnemyIdList[currentEnemyIndex];
                if (enemyDataSheet.TryGetEnemyData(enemyId, out var enemyData))
                {
                    frontArea.uiEnemies[currentWaveData.FrontIdList[frontIndex]].SetEnemy(enemyData);
                }

                ++currentEnemyIndex;
            }
        }

        if (backIdList != null)
        {
            for (int backIndex = 0; backIndex < backIdList.Count; ++backIndex)
            {
                int enemyId = currentWaveData.EnemyIdList[currentEnemyIndex];
                if (enemyDataSheet.TryGetEnemyData(enemyId, out var enemyData))
                {
                    backArea.uiEnemies[currentWaveData.BackIdList[backIndex]].SetEnemy(enemyData);
                }

                ++currentEnemyIndex;
            }
        }
    }

    public List<Enemy> GetEnemyList()
    {
        List<Enemy> enemies = new List<Enemy>();
        enemies.AddRange(backArea.GetEnemyList());
        enemies.AddRange(frontArea.GetEnemyList());

        return enemies;
    }

    public void InitializeEnemyPositions()
    {
        backArea.InitializeEnemyPositions();
        frontArea.InitializeEnemyPositions();
    }
}
