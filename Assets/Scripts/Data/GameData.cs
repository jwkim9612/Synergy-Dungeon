using System.Collections.Generic;

//[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        level = 1;
        coin = 0;
        playableStage = 1;
    }

    public int level;
    public int coin;
    public int playableStage;
}

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
        MagicAttack = characterAbilityData.MagicAttack;
        Health = characterAbilityData.Health;
        Defence = characterAbilityData.Defence;
        MagicDefence = characterAbilityData.MagicDefence;
        Shield = characterAbilityData.Shield;
        Accuracy = characterAbilityData.Accuracy;
        Evasion = characterAbilityData.Evasion;
        AttackSpeed = characterAbilityData.AttackSpeed;
    }

    public void SetAbility(EnemyData enemyData)
    {
        Attack = enemyData.Attack;
        MagicAttack = enemyData.MagicAttack;
        Health = enemyData.Health;
        Defence = enemyData.Defence;
        MagicDefence = enemyData.MagicDefence;
        Shield = enemyData.Shield;
        Accuracy = enemyData.Accuracy;
        Evasion = enemyData.Evasion;
        AttackSpeed = enemyData.AttackSpeed;
    }

    public long Attack;
    public long MagicAttack;
    public long Health;
    public long Defence;
    public long MagicDefence;
    public long Shield;
    public long Accuracy;
    public long Evasion;
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

//public enum Tribe
//{ 
//    None,
//    Human,
//    Elf,
//    Devil,
//    Undead,
//    Elemental,
//    Machine,
//    Beast
//}

//public enum Origin
//{ 
//    None,
//    Warrior,
//    Knight,
//    Archer,
//    Thief, 
//    Priest,
//    Dragon,
//}

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
    기계,
    드래곤,
    악마,
    야수,
    언데드,
    엘프,
    정령,
    휴먼
}

public enum Origin
{
    None,
    궁수,
    도적,
    법사,
    성기사,
    전사
}
