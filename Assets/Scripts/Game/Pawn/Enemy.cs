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
    }

    public override float GetAttackAnimationLength()
    {
        return EnemyService.ATTACK_ANIMATION_LENGTH;
    }

    public void SetAbility(EnemyData enemyData)
    {
        ability = new AbilityData();
        ability.SetAbilityData(enemyData);

        currentHP = ability.Health;
    }

    protected override IEnumerator Co_AttackAndAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            this.gameObject.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
            yield return new WaitForEndOfFrame();
        }

        AttackProcessing();

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 5; i++)
        {
            this.gameObject.transform.Translate(new Vector3(0.1f, 0.0f, 0.0f));
            yield return new WaitForEndOfFrame();
        }
    }

    public override void RandomAttack()
    {
        var battleStatus = InGameManager.instance.backCanvas.uiMainMenu.uiBattleArea.battleStatus;

        target = battleStatus.GetRandomCharacter();
        Attack(target);
    }
}
