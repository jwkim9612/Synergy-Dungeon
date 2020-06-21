public class Enemy : Pawn
{
    public Enemy()
    {
        pawnType = PawnType.Enemy;
    }

    public void SetAbility(EnemyData enemyData)
    {
        ability.SetAbility(enemyData);

        currentHP = ability.Health;
    }

    public override void RandomAttack()
    {
        target = InGameManager.instance.uiBattleArea.battleStatus.GetRandomCharacter();
        Attack(target);
    }
}
