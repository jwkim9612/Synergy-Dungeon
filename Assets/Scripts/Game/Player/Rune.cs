using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune
{
    private RuneData runeData;
    private Ability ability;

    public void SetRune(RuneData newRuneData)
    {
        runeData = newRuneData;
        ability.SetAbility(runeData);
    }
}
