using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterInfo : UIControl
{
    [SerializeField] private Text characterName = null;

    private CharacterData characterData;

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;
    }

    public override void OnShow()
    {
        characterName.text = characterData.name;

        base.OnShow();
    }
}
