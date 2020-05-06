using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIEnemy : MonoBehaviour
{
    //private EnemyData enemyData;
    public Enemy enemy;

    [SerializeField] private Image image = null;
    
    public void SetEnemy(EnemyData newEnmeyData)
    {
        enemy = new Enemy();
        enemy.SetAbility(newEnmeyData.ability);

        image.sprite = newEnmeyData.image;
        enemy.OnIsDead += OnHide;
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }
}
