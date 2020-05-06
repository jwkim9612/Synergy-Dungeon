using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup = null;
    [SerializeField] private UIEnemy uiEnemy = null;

    private List<UIEnemy> uiEnemies;

    void Start()
    {
        uiEnemies = new List<UIEnemy>();

        InGameManager.instance.gameState.OnPrepare += CreateMonsters;
        //CreateMonsters();
        //Destroy(monsterSlot.gameObject);
    }

    public void CreateMonsters()
    {
        /////////////////////////////// 몬스터 데이터 받아오기 //////////////////////////////////////////////////
        var currentWaveData = GameManager.instance.stageManager.currentStageData.waveData.Sheet[GameManager.instance.stageManager.currentWave - 1];

        for (int i = 0; i < currentWaveData.count.Length; ++i)
        {
            for (int j = 0; j < currentWaveData.count[i]; ++j)
            {
                var enemy = Instantiate(uiEnemy, verticalLayoutGroup.transform);
                enemy.SetEnemy(GameManager.instance.dataSheet.enemyDatas[currentWaveData.monsterNum[i]]);
                uiEnemies.Add(enemy);
            }
        }
        /////////////////////////////// //////////////////// //////////////////////////////////////////////////
        ///

        // 후에 수정 필요
        uiEnemy.gameObject.SetActive(false);
    }

    public void DestroyMonsters()
    {
        foreach(var uiEnemy in uiEnemies)
        {
            Destroy(uiEnemy.gameObject);
        }

        uiEnemies.Clear();

        uiEnemy.gameObject.SetActive(true);
    }

    public List<Enemy> GetEnemyList()
    {
        List<Enemy> enemys = new List<Enemy>();
        
        foreach(var uiEnemy in uiEnemies)
        {
            if (uiEnemy.enemy != null)
            {
                enemys.Add(uiEnemy.enemy);
            }
        }

        return enemys;
    }
}
