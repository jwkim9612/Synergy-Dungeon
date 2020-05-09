using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : Arranger
{
    private void Start()
    {
        base.Start();
        
        if(SaveManager.Instance.HasInGameData())
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.prepareAreaInfoList);
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

}
