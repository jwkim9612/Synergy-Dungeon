using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIEnemyPlacementArea : MonoBehaviour
{
    public List<UIEnemy> uiEnemies = null;

    private void Start()
    {
        uiEnemies = GetComponentsInChildren<UIEnemy>().ToList();
    }

    public List<Enemy> GetEnemyList()
    {
        List<Enemy> enemies = new List<Enemy>();

        foreach (var uiEnemy in uiEnemies)
        {
            if (uiEnemy.gameObject.activeSelf)
            {
                enemies.Add(uiEnemy.enemy);
            }
        }

        return enemies;
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
