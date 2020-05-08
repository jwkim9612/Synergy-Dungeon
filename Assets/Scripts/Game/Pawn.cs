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
    public delegate void OnHitForDamageDelegate(float damage);
    [JsonIgnore] public OnHitForDamageDelegate OnHitForDamage;
    public delegate void OnIsDeadDelegate();
    [JsonIgnore] public OnIsDeadDelegate OnIsDead;

    public string name;
    public AbilityData ability;
    public PawnType pawnType;
    public bool isDead;
    private int currentHP;

    public void Attack(Pawn target)
    {
        int finalDamage = target.TakeDamage(ability.attack);
        OnAttack();

        InGameManager.instance.battleLogService.AddBattleLog(name + "(이)가 " + target.name + "(이)에게 " + finalDamage + "데미지를 입혔습니다.");
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage">받은 데미지</param>
    /// <returns>최종적으로 입은 데미지</returns>
    public int TakeDamage(int damage)
    {
        int finalDamage = Mathf.Clamp(damage - ability.defense, 1, damage);
        currentHP = Mathf.Clamp(currentHP - finalDamage, 0, currentHP);

        OnHit();
        OnHitForDamage(finalDamage);

        if (currentHP <= 0)
        {
            isDead = true;
            OnIsDead();
        }

        return finalDamage;
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

    public float GetHPRatio()
    {
        return currentHP / (float)ability.maxHP;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}
