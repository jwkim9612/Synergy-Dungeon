using System.Collections;
using UnityEngine;

public class Character : Pawn
{
    public Animator animator;

    public Character()
    {
        pawnType = PawnType.Character;
    }

    public override void Initialize()
    {
        base.Initialize();
        animator = GetComponent<Animator>();

        floatingTextIndex = 0;
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

    //public override void Attack(Pawn target)
    //{
    //    if (target == null)
    //    {
    //        Debug.Log("target is null");
    //        return;
    //    }

    //    this.target = target;

    //    StartCoroutine(Co_Attack());
    //}

    protected override IEnumerator Co_Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
            yield return new WaitForEndOfFrame();
        }

        // 공격
        if (GetAttackSuccessful(target))
        {
            if (IsCriticalAttack())
                target.TakeDamage(ability.Attack, true);
            else
                target.TakeDamage(ability.Attack, false);
        }
        else
            target.PlayMissText();
        //

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 5; i++)
        {
            this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
            yield return new WaitForEndOfFrame();
        }
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

    public void SetRunTimeAnimatorController(RuntimeAnimatorController runTimeAnimatorController)
    {
        animator.runtimeAnimatorController = runTimeAnimatorController;
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

    public override void PlayAttackAnimation()
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetBool("Attack", true);
        }
    }

    // Win 애니메이션에서 사용함.
    private void WinEnd()
    {
        animator.SetBool("Win", false);
    }

    // Attack 애니메이션에서 사용함.
    private void AttackEnd()
    {
        animator.SetBool("Attack", false);
    }

    public override float GetAttackAnimationLength()
    {
        if (animator == null)
        {
            return 1.0f;
        }

        if (animator.runtimeAnimatorController != null)
        {
            RuntimeAnimatorController ac = animator.runtimeAnimatorController;
            for (int i = 0; i < ac.animationClips.Length; i++)
            {
                if (ac.animationClips[i].name == "Attack")
                {
                    return ac.animationClips[i].length;
                }
            }
        }
        else
        {
            return 1.0f;
        }

        Debug.LogError("Error GetAttackAnimationLength");
        return -1;
    }

    public bool HasAnimation()
    {
        if (animator != null)
        {
            if (animator.runtimeAnimatorController != null)
            {
                return true;
            }
        }

        return false;
    }

    protected override IEnumerator Co_TakeHitAnimation()
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
}
