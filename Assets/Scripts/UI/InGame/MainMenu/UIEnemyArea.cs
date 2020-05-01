using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyArea : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup = null;
    [SerializeField] private UIEnemy uiEnemy = null;

    private List<UIEnemy> enemies;

    void Start()
    {
        enemies = new List<UIEnemy>();

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
                enemy.SetEnemyData(GameManager.instance.dataSheet.enemyDatas[currentWaveData.monsterNum[i]]);
                enemies.Add(enemy);
            }
        }
        /////////////////////////////// //////////////////// //////////////////////////////////////////////////
        ///

        // 후에 수정 필요
        uiEnemy.gameObject.SetActive(false);
    }

    public void DestroyMonsters()
    {
        foreach(var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        enemies.Clear();

        uiEnemy.gameObject.SetActive(true);
    }
}
