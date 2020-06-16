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

    public void SetAbility(CharacterAbilityData characterAbilityData, Origin origin)
    {
        ability.SetAbility(characterAbilityData);

        ///////////////////////////////////// 룬 능력치 + ///////////////////////////////////////////////
        Rune rune = RuneManager.Instance.GetEquippedRuneOfOrigin(origin);
        if(rune != null)
        {
            ability += rune.runeData.Ability;
            Debug.Log("어빌맅  더하기");
        }
        ///////////////////////////////////// ///////////// ///////////////////////////////////////////////



        currentHP = ability.Health;
    }

    public override void RandomAttack()
    {
        target = InGameManager.instance.uiBattleArea.battleStatus.GetRandomEnemy();
        Attack(target);
    }

    public override void ResetStat()
    {
        base.ResetStat();
        currentHP = ability.Health;
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
