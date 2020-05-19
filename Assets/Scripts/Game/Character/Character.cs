using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class Character : Pawn
{
    public CharacterAbilityData ability { get; set; }

    public Character()
    {
        pawnType = PawnType.Character;
    }

    public void SetAbility(CharacterAbilityData newAbility)
    {
        ability = newAbility;

        currentHP = ability.Health;
        currentAttackSpeed = ability.AttackSpeed;
    }

    public override void Attack(Pawn target)
    {
        float finalDamage = target.TakeDamage(ability.Attack);
        OnAttack();

        //InGameManager.instance.battleLogService.AddBattleLog(name + "(이)가 " + target.name + "(이)에게 " + finalDamage + "데미지를 입혔습니다.");
    }

    public override long TakeDamage(long damage)
    {
        long finalDamage = Mathf.Clamp((int)(damage) - (int)(ability.Defence), 1, (int)(damage));
        currentHP = Mathf.Clamp((int)(currentHP - finalDamage), 0, (int)(currentHP));

        OnHit();

        PlayHitText(finalDamage);

        if (currentHP <= 0)
        {
            isDead = true;
            OnIsDead();
        }

        return finalDamage;
    }

    public override void ResetStat()
    {
        base.ResetStat();
        currentHP = ability.Health;
    }

    public override float GetHPRatio()
    {
        return currentHP / (float)ability.Health;
    }

    public float GetSize()
    {
        return spriteRenderer.transform.localScale.x;
    }

    public void OnHide()
    {
        spriteRenderer.gameObject.SetActive(false);
    }

    public void OnShow()
    {
        spriteRenderer.gameObject.SetActive(true);

    }
}
