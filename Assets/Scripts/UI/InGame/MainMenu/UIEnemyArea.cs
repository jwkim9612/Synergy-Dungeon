using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    [SerializeField] private List<UIEnemy> uiEnemies = null;
    public UIEnemyPlacementArea backArea;
    public UIEnemyPlacementArea frontArea;

    void Start()
    {
        InGameManager.instance.gameState.OnBattle += InitializeEnemyPositions;
        InGameManager.instance.gameState.OnPrepare += CreateEnemies;
    }

    public void CreateEnemies()
    {
        var currentWaveData = StageManager.Instance.currentChapterData.chapterInfoDataList[StageManager.Instance.currentWave - 1];

        int currentEnemyIndex = 0;

        //for (int i = 0; i < currentWaveData.count.Length; ++i)
        //{
        //    for (int j = 0; j < currentWaveData.count[i]; ++j)
        //    {
        //        if (currentEnemyIndex > uiEnemies.Count)
        //            break;

        //        uiEnemies[currentEnemyIndex].gameObject.SetActive(true);
        //        uiEnemies[currentEnemyIndex].SetEnemy(GameManager.instance.dataSheet.enemyDatas[currentWaveData.monsterNum[i]]);
        //        ++currentEnemyIndex;
        //    }
        //}

        //for(int i = currentEnemyIndex; i < uiEnemies.Count; ++i)
        //{
        //    uiEnemies[i].gameObject.SetActive(false);
        //}
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
