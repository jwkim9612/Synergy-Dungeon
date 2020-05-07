using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using Newtonsoft.Json;

public class Pawn
{
    public delegate void OnAttackDelegate();
    [JsonIgnore] public OnAttackDelegate OnAttack; 
    public delegate void OnHitDelegate();
    [JsonIgnore] public OnHitDelegate OnHit;
    public delegate void OnIsDeadDelegate();
    [JsonIgnore] public OnIsDeadDelegate OnIsDead;

    public AbilityData ability;
    public PawnType pawnType;
    public bool isDead;
    private int currentHP;

    public void Attack(Pawn pawn)
    {
        pawn.TakeDamage(ability.attack);
        OnAttack();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(GetType());
        Debug.Log("원래 HP : " + currentHP);

        OnHit();

        int finalDamage = Mathf.Clamp(damage - ability.defense, 1, damage);
        currentHP = Mathf.Clamp(currentHP - finalDamage, 0, currentHP);

        if(currentHP <= 0)
        {
            isDead = true;
            OnIsDead();
            Debug.Log(GetType());
            Debug.Log("주금");
        }

        Debug.Log("공격 받은 후 HP : " + currentHP);
    }

    public void SetAbility(AbilityData newAbility)
    {
        ability = newAbility;

        currentHP = ability.maxHP;
    }

    public void ResetStat()
    {
        currentHP = ability.maxHP;
        isDead = false;
    }

}
