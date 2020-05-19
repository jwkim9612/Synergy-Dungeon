using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : Arranger
{
    public void Initialize()
    {
        base.Initialize();
        
        if(SaveManager.Instance.HasInGameData())
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.prepareAreaInfoList);
        }

        InGameManager.instance.gameState.OnBattle += HideAllCharacters;
        InGameManager.instance.gameState.OnPrepare += ShowAllCharacters;
    }

    public override void UpdateChildren()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (i == uiCharacters.Count)
            {
                uiCharacters.Add(null);
            }

            // border안에 또 캐릭터가 있어서 GetChild를 두 번 써줌
            var uicharacter = gameObject.GetComponentsInChildren<UISlot>()[i].GetComponentInChildren<UICharacter>();

            if (uicharacter != uiCharacters[i])
            {
                uiCharacters[i] = uicharacter;

                if (uiCharacters[i].character != null)
                {
                    uiCharacters[i].character.SetSize(0.5f);
                }
            }
        }
    }

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

    public void HideAllCharacters()
    {
        foreach (var uiCharacter in uiCharacters)
        {
            if (uiCharacter.character == null)
                continue;

            uiCharacter.character.OnHide();
        }
    }

    public void ShowAllCharacters()
    {
        foreach (var uiCharacter in uiCharacters)
        {
            if (uiCharacter.character == null)
                continue;

            uiCharacter.character.OnShow();
        }
    }
}
