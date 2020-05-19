using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    //[SerializeField] private List<UIEnemy> uiEnemies = null;
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
        var currentWaveData = StageManager.Instance.currentChapterData.chapterInfoDataList[StageManager.Instance.currentWave - 1];

        int currentEnemyIndex = 0;

        for (int frontIndex = 0; frontIndex < currentWaveData.FrontIdList.Count; ++frontIndex)
        {
            frontArea.uiEnemies[currentWaveData.FrontIdList[frontIndex]].SetEnemy(GameManager.instance.dataSheet.enemyDataSheet.EnemyDatas[currentWaveData.EnemyIdList[currentEnemyIndex]]);
            ++currentEnemyIndex;
        }

        for (int backIndex = 0; backIndex < currentWaveData.BackIdList.Count; ++backIndex)
        {
            backArea.uiEnemies[currentWaveData.BackIdList[backIndex]].SetEnemy(GameManager.instance.dataSheet.enemyDataSheet.EnemyDatas[currentWaveData.EnemyIdList[currentEnemyIndex]]);
            ++currentEnemyIndex;
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
