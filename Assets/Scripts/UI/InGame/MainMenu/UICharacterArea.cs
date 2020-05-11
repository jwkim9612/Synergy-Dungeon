using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterArea : Arranger
{
    protected void Start()
    {
        base.Start();

        InGameManager.instance.gameState.OnBattle += OnFighting;
        InGameManager.instance.gameState.OnPrepare += OffFighting;

        if (SaveManager.Instance.HasInGameData())
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.characterAreaInfoList);
        }
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

        if(characters.Count == 0)
        {
            return null;
        }

        return characters;
    }

    /// <summary>
    /// 캐릭터가 들어있는 UICharacter리스트를 반환
    /// </summary>
    /// <returns> 캐릭터가 들어있는 UICharacter리스트 </returns>
    public List<UICharacter> GetUICharacterListWithCharacters()
    {
        List<UICharacter> uiCharacters = new List<UICharacter>();

        foreach (var uiCharacter in this.uiCharacters)
        {
            if (uiCharacter.character != null)
            {
                uiCharacters.Add(uiCharacter);
            }
        }

        return uiCharacters;
    }

    public void ShowAllUICharacters()
    {
        foreach(var uiCharacter in uiCharacters)
        {
            uiCharacter.gameObject.SetActive(true);
        }
    }

    public bool IsEmpty()
    {
        foreach (var uiCharacter in uiCharacters)
        {
            if(uiCharacter.character != null)
            {
                return false;
            }
        }

        return true;
    }
}
