using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterData
{
    public int Id;
    public string Name;
    public Tribe Tribe;
    public Origin Origin;
    public Tier Tier;
    public string ImagePath;

    public Sprite Image;
    public OriginData OriginData;
    public TribeData TribeData;
}

