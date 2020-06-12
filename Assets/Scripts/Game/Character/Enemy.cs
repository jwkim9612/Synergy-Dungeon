using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using System.Configuration;

public class Enemy : Pawn
{
    public Enemy()
    {
        pawnType = PawnType.Enemy;
    }

    public void SetAbility(EnemyData enemyData)
    {
        ability.SetAbility(enemyData);

        currentHP = ability.Health;
    }

    public override void RandomAttack()
    {
        target = InGameManager.instance.uiBattleArea.battleStatus.GetRandomCharacter();
        Attack(target);
    }
}
