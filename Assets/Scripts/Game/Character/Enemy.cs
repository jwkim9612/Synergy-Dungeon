using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class Enemy : Pawn
{
    public Enemy()
    {
        pawnType = PawnType.Enemy;
    }
    //private AbilityData ability;
    //private int currentHP;

    //public void Attack(Character character)
    //{
    //    character.TakeDamage(ability.attack);
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
