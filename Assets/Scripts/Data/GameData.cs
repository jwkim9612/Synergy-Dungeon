﻿using System.Collections.Generic;

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
