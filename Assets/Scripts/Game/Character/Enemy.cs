using System.Collections;
using UnityEngine;

public class Enemy : Pawn
{
    public Enemy()
    {
        pawnType = PawnType.Enemy;
    }

    public override void Initialize()
    {
        base.Initialize();

        OnIsDead += PlayDeadAnimation;
    }

    public override float GetAttackAnimationLength()
    {
        return 2.0f;
    }

    public void SetAbility(EnemyData enemyData)
    {
        ability.SetAbility(enemyData);

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
            this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
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
            this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
            yield return new WaitForEndOfFrame();
        }
    }

    private void PlayDeadAnimation()
    {
        StartCoroutine(Co_DeadAnimation());
    }

    protected override void PlayTakeHit()
    {
        StartCoroutine(Co_TakeHitAnimation());
        StartCoroutine(Co_TakeHit());
    }

    private IEnumerator Co_DeadAnimation()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = false;
        DestoryPawn();
        yield break;
    }

    private IEnumerator Co_TakeHit()
    {
        float temp = 0.0f;
        float defaultX = this.gameObject.transform.position.x;
        float defaultY = this.gameObject.transform.position.y;
        float defaultZ = this.gameObject.transform.position.z;


        while (temp <= 0.29f)
        {
            //Vector3.SmoothDamp()

            //temp = Vector3.Slerp(new Vector3(defaultX, defaultY, defaultZ), 0.3f, 0.05f);
            this.transform.position = new Vector3(defaultX + temp, defaultY, defaultZ);
            yield return new WaitForEndOfFrame();

            //this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
        }


        while (temp > 0.0f)
        {
            //temp = Mathf.Slerp(temp, -0.01f, 0.05f);
            this.transform.position = new Vector3(defaultX + temp, defaultY, defaultZ);
            yield return new WaitForEndOfFrame();

            //this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
        //    yield return new WaitForSeconds(0.05f);
        //}

        yield return new WaitForSeconds(0.1f);

        //for (int i = 0; i < 3; i++)
        //{
        //    this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
        //    yield return new WaitForSeconds(0.05f);
        //}

        yield return new WaitForSeconds(0.5f);

        if (isDead)
        {
            OnIsDead();
        }
    }

    protected override IEnumerator Co_TakeHitAnimation()
    {
        spriteRenderer.material = MaterialService.whiteMaterial;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material = MaterialService.redMaterial;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material = MaterialService.whiteMaterial;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material = MaterialService.redMaterial;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material = MaterialService.whiteMaterial;

        spriteRenderer.material = defaultMaterial;
    }

    public override void RandomAttack()
    {
        target = InGameManager.instance.uiBattleArea.battleStatus.GetRandomCharacter();
        Attack(target);
    }
}
