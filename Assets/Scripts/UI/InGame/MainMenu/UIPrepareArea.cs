using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : Arranger
{
    private void Start()
    {
        base.Start();

        var loadInGameData = SaveManager.Instance.LoadInGameData();
        if (loadInGameData != null)
        {
            InitializeByLoadInGameData(loadInGameData.prepareAreaInfoList);
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
