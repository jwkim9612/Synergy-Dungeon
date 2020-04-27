using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : Arranger
{
    public (bool isBuying, UICharacter uiCharacter) BuyCharacter()
    {
        foreach(var uiCharacter in uiCharacters)
        {
            if (uiCharacter.characterInfo.star != 0)
                continue;

            return (true, uiCharacter);
        }

        return (false, null);
    }
}
