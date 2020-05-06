using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterArea : Arranger
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

    public List<Character> GetCharacterList()
    {
        List<Character> characters = new List<Character>();

        foreach (var uiCharacter in uiCharacters)
        {
            if(uiCharacter.character != null)
            {
                characters.Add(uiCharacter.character);
            }
            
        }

        return characters;
    }
}
