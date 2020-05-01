using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleArea : Arranger
{
    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += OnFighting;
        InGameManager.instance.gameState.OnPrepare += OffFighting;
    }

    public void OnFighting()
    {
        foreach(var uiCharacter in uiCharacters)
        {
            uiCharacter.isFightingOnBattlefield = true;
        }
    }

    public void OffFighting()
    {
        foreach (var uiCharacter in uiCharacters)
        {
            uiCharacter.isFightingOnBattlefield = false;
        }
    }

}
