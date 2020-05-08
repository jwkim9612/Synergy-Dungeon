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

    public string name;
    public AbilityData ability;
    public PawnType pawnType;
    public bool isDead;
    private int currentHP;

    [JsonIgnore] public UIHitText[] uiHitTexts = null;
    [JsonIgnore] private int hitTextIndex;

    private void Start()
    {
        hitTextIndex = 0;
    }

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

        PlayHitText(finalDamage);

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

    public void SetUIHitTexts(UIHitText[] uiHitTexts)
    {
        this.uiHitTexts = uiHitTexts;
    }

    public void InitializeUIHitTexts()
    {
        if (uiHitTexts != null)
        {
            foreach(var uiHitText in uiHitTexts)
            {
                uiHitText.Initialize();
            }
        }
    }

    private void PlayHitText(int damage)
    {
        uiHitTexts[hitTextIndex].SetDamageText(damage.ToString());
        uiHitTexts[hitTextIndex].Play();

        ++hitTextIndex;

        if (hitTextIndex >= uiHitTexts.Length)
            hitTextIndex = 0;
    }
}
