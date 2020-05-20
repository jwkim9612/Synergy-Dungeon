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

    //public override void Attack(Pawn target)
    //{
    //    if (target == null)
    //        Debug.Log("target is null");

    //    float finalDamage = target.TakeDamage(ability.Attack);
    //    OnAttack();

    //    //InGameManager.instance.battleLogService.AddBattleLog(name + "(이)가 " + target.name + "(이)에게 " + finalDamage + "데미지를 입혔습니다.");
    //}

    //public override long TakeDamage(long damage)
    //{
    //    long finalDamage = Mathf.Clamp((int)(damage) - (int)(ability.Defence), 1, (int)(damage));
    //    currentHP = Mathf.Clamp((int)(currentHP - finalDamage), 0, (int)(currentHP));

    //    OnHit();

    //    PlayHitText(finalDamage);

    //    if (currentHP <= 0)
    //    {
    //        isDead = true;
    //        OnIsDead();
    //    }

    //    return finalDamage;
    //}
}
