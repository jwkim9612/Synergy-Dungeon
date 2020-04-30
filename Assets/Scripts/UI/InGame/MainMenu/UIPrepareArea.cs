using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : Arranger
{
    public UICharacter GetEmptyUICharacter()
    {
        foreach(var uiCharacter in uiCharacters)
        {
            if (uiCharacter.characterInfo.star != 0)
                continue;

            return uiCharacter;
        }

        return null;
    }
}
