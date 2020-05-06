using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class Character : Pawn
{
    public Character()
    {
        pawnType = PawnType.Character;
    }

    //private AbilityData ability;
    //private int currentHP;

    //public void Attack(Enemy enemy)
    //{
    //    enemy.TakeDamage(ability.attack);
    //}

    //public void TakeDamage(int damage)
    //{
    //    int finalDamage = Mathf.Clamp(damage - ability.defense, 1, damage);
    //    currentHP = Mathf.Clamp(currentHP - finalDamage, 0, currentHP);
    //}

    //public void SetAbility(AbilityData newAbility)
    //{
    //    ability = newAbility;

    //    currentHP = ability.maxHP;
    //}
}
