using System.Collections.Generic;

//[System.Serializable]

public class AccountData
{ 
    public string id;
    public string pw;
    public bool isLoginToGoogle;
}

public struct Ability
{
    public void SetAbility(CharacterAbilityData characterAbilityData)
    {
        Attack = characterAbilityData.Attack;
        MagicalAttack = characterAbilityData.MagicalAttack;
        Health = characterAbilityData.Health;
        Defence = characterAbilityData.Defence;
        MagicDefence = characterAbilityData.MagicDefence;
        Shield = characterAbilityData.Shield;
        Accuracy = characterAbilityData.Accuracy;
        Evasion = characterAbilityData.Evasion;
        Critical = characterAbilityData.Critical;
        AttackSpeed = characterAbilityData.AttackSpeed;
    }

    public void SetAbility(EnemyData enemyData)
    {
        Attack = enemyData.Attack;
        MagicalAttack = enemyData.MagicalAttack;
        Health = enemyData.Health;
        Defence = enemyData.Defence;
        MagicDefence = enemyData.MagicDefence;
        Shield = enemyData.Shield;
        Accuracy = enemyData.Accuracy;
        Evasion = enemyData.Evasion;
        Critical = enemyData.Critical;
        AttackSpeed = enemyData.AttackSpeed;
    }

    public void SetAbility(RuneData runeData)
    {
        Attack = runeData.Attack;
        MagicalAttack = runeData.MagicalAttack;
        Health = runeData.Health;
        Defence = runeData.Defence;
        MagicDefence = runeData.MagicDefence;
        Shield = runeData.Shield;
        Accuracy = runeData.Accuracy;
        Evasion = runeData.Evasion;
        Critical = runeData.Critical;
        AttackSpeed = runeData.AttackSpeed;
    }

    public long Attack;
    public long MagicalAttack;
    public long Health;
    public long Defence;
    public long MagicDefence;
    public long Shield;
    public long Accuracy;
    public long Evasion;
    public long Critical;
    public long AttackSpeed;
}


public struct CharacterInfo
{
    public CharacterInfo(int id, int star)
    {
        this.id = id;
        this.star = star;
    }

    public int id;
    public int star;
}

public struct TribeInfo
{
    public TribeInfo(Tribe tribe, int id)
    {
        this.tribe = tribe;
        this.id = id;
    }

    public Tribe tribe;
    public int id;
}

public struct OriginInfo
{
    public OriginInfo(Origin origin, int id)
    {
        this.origin = origin;
        this.id = id;
    }

    public Origin origin;
    public int id;
}

public enum Tier
{ 
    None,
    One,
    Two,
    Three,
    Four,
    Five
}

public enum InGameState
{ 
    None,
    Prepare,
    Battle,
    Complete,
    Lose
}

public enum PawnType
{ 
    Character,
    Enemy
}

public enum Tribe
{
    None,
    Beast,
    Devil,
    Dragon,
    Elemental,
    Elf,
    Human,
    Machine,
    Undead
}

public enum Origin
{
    None,
    Archer,
    Paladin,
    Thief,
    Warrior,
    Wizard
}
