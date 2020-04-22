using System.Collections.Generic;

//[System.Serializable]
public class GameData
{
    public int level = 1;
    public int coin = 0;
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
    Play,
    Complete,
    Lose
}

