using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    [SerializeField] private List<UIEnemy> uiEnemies = null;

    void Start()
    {
        InGameManager.instance.gameState.OnBattle += InitializeEnemyPositions;
        InGameManager.instance.gameState.OnPrepare += CreateEnemies;
    }

    public void CreateEnemies()
    {
        var currentWaveData = StageManager.Instance.currentStageData.waveData.Sheet[StageManager.Instance.currentWave - 1];

        int currentEnemyIndex = 0;

        for (int i = 0; i < currentWaveData.count.Length; ++i)
        {
            for (int j = 0; j < currentWaveData.count[i]; ++j)
            {
                if (currentEnemyIndex > uiEnemies.Count)
                    break;

                uiEnemies[currentEnemyIndex].gameObject.SetActive(true);
                uiEnemies[currentEnemyIndex].SetEnemy(GameManager.instance.dataSheet.enemyDatas[currentWaveData.monsterNum[i]]);
                ++currentEnemyIndex;
            }
        }

        for(int i = currentEnemyIndex; i < uiEnemies.Count; ++i)
        {
            uiEnemies[i].gameObject.SetActive(false);
        }
    }

    public List<Enemy> GetEnemyList()
    {
        List<Enemy> enemys = new List<Enemy>();
        
        foreach(var uiEnemy in uiEnemies)
        {
            if (uiEnemy.gameObject.activeSelf)
            {
                enemys.Add(uiEnemy.enemy);
            }
        }

        return enemys;
    }

    public void InitializeEnemyPositions()
    {
        foreach (var uiEnemy in uiEnemies)
        {
            if (uiEnemy.enemy == null)
                continue;

            StartCoroutine(uiEnemy.Co_FollowEnemy());
        }
    }
}
