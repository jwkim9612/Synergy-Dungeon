using System.Collections;
using UnityEngine;

public class Character : Pawn
{
    public Origin origin;
    public CharacterInfo characterInfo { get; set; }

    public Character()
    {
        pawnType = PawnType.Character;
    }

    public void SetAbility(CharacterAbilityData characterAbilityData, Origin newOrigin)
    {
        ability = new AbilityData();
        ability.SetAbilityData(characterAbilityData);
        origin = newOrigin;

        ///////////////////////////////////// 룬 능력치 + ///////////////////////////////////////////////
        Rune rune = RuneManager.Instance.GetEquippedRuneOfOrigin(origin);
        if(rune != null)
        {
            ability += rune.runeData.AbilityData;
            Debug.Log("어빌맅  더하기");
        }
        ///////////////////////////////////// ///////////// ///////////////////////////////////////////////



        currentHP = ability.Health;
    }

    protected override IEnumerator Co_AttackAndAnimation()
    {
        //if (IsMeleeUnit())
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
        //        yield return new WaitForEndOfFrame();
        //    }

        //    AttackProcessing();

        //    yield return new WaitForSeconds(0.5f);

        //    for (int i = 0; i < 5; i++)
        //    {
        //        this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
        //        yield return new WaitForEndOfFrame();
        //    }
        //}
        if (animator.runtimeAnimatorController == null)
        {
            for (int i = 0; i < 5; i++)
            {
                this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
                yield return new WaitForEndOfFrame();
            }

            AttackProcessing();

            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < 5; i++)
            {
                this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            AttackProcessing();
        }

        yield return null;
    }

    public override void RandomAttack()
    {
        var battleStatus = InGameManager.instance.backCanvas.uiMainMenu.uiBattleArea.battleStatus;

        target = battleStatus.GetRandomEnemy();
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

    public void RemoveRunTimeAnimatorController()
    {
        animator.runtimeAnimatorController = null;
    }

    public void PlayWinAnimation()
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetBool("Win", true);
        }
    }

    public override void PlayAttackAnimationAndGetTarget()
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetBool("Attack", true);
        }

        var battleStatus = InGameManager.instance.backCanvas.uiMainMenu.uiBattleArea.battleStatus;
        target = battleStatus.GetRandomEnemy();
        //Attack(target);
    }

    // Win 애니메이션에서 사용함.
    private void WinEnd()
    {
        animator.SetBool("Win", false);
    }

    // 애니메이션이 없는 캐릭터의 데미지를 받을때 애니메이션
    protected IEnumerator Co_TakeHitEffect()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.5f);

        if (isDead)
        {
            OnIsDead();
        }
    }

    private bool IsMeleeUnit()
    {
        if (origin == Origin.Archer || origin == Origin.Wizard)
            return false;

        return true;
    }

    public override bool IsActivated()
    {
        return characterInfo == null ? false : true;
    }
}
