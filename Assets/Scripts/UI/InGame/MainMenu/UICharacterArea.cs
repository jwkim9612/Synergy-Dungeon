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

        var loadInGameData = SaveManager.Instance.LoadInGameData();
        if (loadInGameData != null)
        {
            InitializeByLoadInGameData(loadInGameData.characterAreaInfoList);
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

        return characters;
    }

    /// <summary>
    /// 캐릭터가 들어있는 UICharacter리스트를 반환
    /// </summary>
    /// <returns> 캐릭터가 들어있는 UICharacter리스트 </returns>
    public List<UICharacter> GetUICharacterListWithCharacters()
    {
        List<UICharacter> emptyUICharacters = new List<UICharacter>();

        foreach (var uiCharacter in uiCharacters)
        {
            if (uiCharacter.character != null)
            {
                emptyUICharacters.Add(uiCharacter);
            }

        }

        return emptyUICharacters;
    }

    public void ShowAllUICharacters()
    {
        foreach(var uiCharacter in uiCharacters)
        {
            uiCharacter.gameObject.SetActive(true);
        }
    }
}
