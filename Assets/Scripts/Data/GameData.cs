using System.Collections.Generic;

//[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        level = 1;
        coin = 0;
    }

    public int level;
    public int coin;
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

public enum Tribe
{ 
    None,
    Human,
    Elf,
    Devil,
    Undead,
    Elemental,
    Machine,
    Beast
}

public enum Origin
{ 
    None,
    Warrior,
    Knight,
    Archer,
    Thief, 
    Priest,
    Dragon,
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

