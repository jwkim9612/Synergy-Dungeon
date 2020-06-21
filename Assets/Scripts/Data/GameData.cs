using System.Collections.Generic;

public class AccountData
{ 
    public string id;
    public string pw;
    public bool isLoginToGoogle;
}

public struct Ability
{
    public static Ability operator +(Ability ability1, Ability ability2)
    {
        Ability ability = new Ability();
        ability.Attack = ability1.Attack + ability2.Attack;
        ability.MagicalAttack = ability1.MagicalAttack + ability2.MagicalAttack;
        ability.Health = ability1.Health + ability2.Health;
        ability.Defence = ability1.Defence + ability2.Defence;
        ability.MagicDefence = ability1.MagicDefence + ability2.MagicDefence;
        ability.Shield = ability1.Shield + ability2.Shield;
        ability.Accuracy = ability1.Accuracy + ability2.Accuracy;
        ability.Evasion = ability1.Evasion + ability2.Evasion;
        ability.Critical = ability1.Critical + ability2.Critical;
        ability.AttackSpeed = ability1.AttackSpeed + ability2.AttackSpeed;

        return ability;
    }

    public List<long> GetAbilityList()
    {
        List<long> abilityList = new List<long>();

        abilityList.Add(Attack);
        abilityList.Add(MagicalAttack);
        abilityList.Add(Health);
        abilityList.Add(Defence);
        abilityList.Add(MagicDefence);
        abilityList.Add(Shield);
        abilityList.Add(Accuracy);
        abilityList.Add(Evasion);
        abilityList.Add(Critical);
        abilityList.Add(AttackSpeed);

        return abilityList;
    }

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

    public void SetAbility(RuneExcelData runeExcelData)
    {
        Attack = runeExcelData.Attack;
        MagicalAttack = runeExcelData.MagicalAttack;
        Health = runeExcelData.Health;
        Defence = runeExcelData.Defence;
        MagicDefence = runeExcelData.MagicDefence;
        Shield = runeExcelData.Shield;
        Accuracy = runeExcelData.Accuracy;
        Evasion = runeExcelData.Evasion;
        Critical = runeExcelData.Critical;
        AttackSpeed = runeExcelData.AttackSpeed;
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


//public struct CharacterInfo
//{
//    public CharacterInfo(int id, int star)
//    {
//        this.id = id;
//        this.star = star;
//    }

//    public int id;
//    public int star;
//}

//public struct TribeInfo
//{
//    public TribeInfo(Tribe tribe, int id)
//    {
//        this.tribe = tribe;
//        this.id = id;
//    }

//    public Tribe tribe;
//    public int id;
//}

//public struct OriginInfo
//{
//    public OriginInfo(Origin origin, int id)
//    {
//        this.origin = origin;
//        this.id = id;
//    }

//    public Origin origin;
//    public int id;
//}

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

public enum PurchaseCurrency
{ 
    None,
    Gold,
    Diamond
}


public enum RewardCurrency
{ 
    None,
    Gold,
    Rune,
    RandomRune,
    Relic,
    Artifact
}

public enum InGameCurrency
{
    None,
    Coin,
    Status
}

public enum RuneGrade
{
    None,
    F_0,
    D_0,
    C_0,
    B_0,
    A_0,
    S_0,
    S_1,
    SS_0,
    SS_1,
    SS_2,
    SSS_0,
    SSS_1,
    SSS_2,
    SSS_3
}

public enum RuneRating
{ 
    None,
    Normal,
    Unique
}
