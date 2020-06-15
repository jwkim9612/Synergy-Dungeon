using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using Newtonsoft.Json;
using Shared.Service;
using System.Linq;

public class Pawn : MonoBehaviour
{
    public delegate void OnAttackDelegate();
    public delegate void OnHitDelegate();
    public delegate void OnIsDeadDelegate();
    public OnAttackDelegate OnAttack { get; set; }
    public OnHitDelegate OnHit { get; set; }
    public OnIsDeadDelegate OnIsDead { get; set; }

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public string pawnName { get; set; }
    public PawnType pawnType { get; set; }
    public bool isDead { get; set; }
    public Ability ability;
    protected long currentHP;

    protected Pawn target;

    public List<UIFloatingText> uiFloatingTextList { get; set; } = null;
    private int floatingTextIndex;

    public void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        floatingTextIndex = 0;
        //OnAttack += PlayAttackAnimation;
    }

    public void SetSize(float size)
    {
        spriteRenderer.transform.localScale = new Vector3(size, size, size);
    }

    public void SetImage(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void SetRunTimeAnimatorController(RuntimeAnimatorController runTimeAnimatorController)
    {
        animator.runtimeAnimatorController = runTimeAnimatorController;
    }

    public void RemoveRunTimeAnimatorController()
    {
        animator.runtimeAnimatorController = null;
    }

    public void Attack(Pawn target)
    {
        if (target == null)
        {
            Debug.Log("target is null");
            return;
        }

        if (GetAttackSuccessful(target))
        {
            if (IsCriticalAttack())
                target.TakeDamage(ability.Attack, true);
            else
                target.TakeDamage(ability.Attack, false);
        }
        else
            target.PlayMissText();


        //InGameManager.instance.battleLogService.AddBattleLog(name + "(이)가 " + target.name + "(이)에게 " + finalDamage + "데미지를 입혔습니다.");
    }

    public virtual void RandomAttack()
    {
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    /// <param name="damage">받은 데미지</param>
    /// <returns>최종적으로 입은 데미지</returns>
    public long TakeDamage(long damage, bool isCritical)
    {
        long finalDamage;

        if (isCritical)
        {
            finalDamage = Mathf.Clamp((int)(damage * 2) - (int)(ability.Defence), 1, (int)damage);
            PlayCriticalHitText(finalDamage);
        }
        else
        {
            finalDamage = Mathf.Clamp((int)damage - (int)(ability.Defence), 1, (int)damage);
            PlayHitText(finalDamage);
        }

        currentHP = Mathf.Clamp((int)(currentHP - finalDamage), 0, (int)currentHP);
        OnHit();

        if (currentHP <= 0)
        {
            isDead = true;
            OnIsDead();
        }

        return finalDamage;
    }

    public virtual void ResetStat()
    {
        isDead = false;
    }

    public float GetHPRatio()
    {
        return currentHP / (float)ability.Health;
    }

    private bool GetAttackSuccessful(Pawn target)
    {
        long currentAccuracy = ability.Accuracy - target.ability.Evasion;
        long randomAccuracyNum = RandomService.GetRandomLong();

        if (currentAccuracy <= randomAccuracyNum)
            return false;
        else
            return true;
    }

    private bool IsCriticalAttack()
    {
        long currentCritical = ability.Critical;
        long randomCriticalNum = RandomService.GetRandomLong();

        if (currentCritical <= randomCriticalNum)
            return false;
        else
            return true;
    }

    public void SetName(string name)
    {
        pawnName = name;
    }

    public void SetUIFloatingTextList(List<UIFloatingText> uiFloatingTextList)
    {
        this.uiFloatingTextList = uiFloatingTextList;
    }

    public void InitializeUIFloatingTextList()
    {
        if (uiFloatingTextList != null)
        {
            foreach(var uiFloatingText in uiFloatingTextList)
            {
                uiFloatingText.Initialize();
            }
        }
    }

    private void PlayHitText(float damage)
    {
        uiFloatingTextList[floatingTextIndex].SetText(damage.ToString(), Color.red);
        uiFloatingTextList[floatingTextIndex].SetTextSize(InGameService.DEFAULT_DAMAGE_FONT_SIZE);
        PlayFloatingText();
    }

    private void PlayCriticalHitText(float damage)
    {
        Color orange = new Color(1.0f, 0.64f, 0.0f);
        uiFloatingTextList[floatingTextIndex].SetText(damage.ToString(), orange);
        uiFloatingTextList[floatingTextIndex].SetTextSize(InGameService.CRITICAL_DAMAGE_FONT_SIZE);
        PlayFloatingText();
    }

    private void PlayMissText()
    {
        uiFloatingTextList[floatingTextIndex].SetText("Miss", Color.gray);
        uiFloatingTextList[floatingTextIndex].SetTextSize(InGameService.MISS_FONT_SIZE);
        PlayFloatingText();
    }

    private void PlayFloatingText()
    {
        uiFloatingTextList[floatingTextIndex].Play();
        ++floatingTextIndex;

        if (floatingTextIndex >= uiFloatingTextList.Count)
            floatingTextIndex = 0;
    }

    public void DestoryPawn()
    {
        Destroy(this.gameObject);
    }

    public void PlayWinAnimation()
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetBool("Win", true);
        }
    }

    public void PlayAttackAnimation()
    {
        if(animator.runtimeAnimatorController != null)
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
    
    public float GetAttackAnimationLength()
    {
        if (animator != null)
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

    public Pawn GetTarget()
    {
        return target;
    }
}
