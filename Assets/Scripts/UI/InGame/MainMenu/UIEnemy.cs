using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIEnemy : MonoBehaviour
{
    private EnemyData enemyData;

    [SerializeField] private Image image = null;
    
    public void SetEnemyData(EnemyData newEnmeyData)
    {
        enemyData = newEnmeyData;

        image.sprite = enemyData.image;
    }

}
