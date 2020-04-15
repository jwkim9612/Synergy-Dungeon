using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterInfo : UIControl
{ 
    [SerializeField] private Text characterName = null;
    [SerializeField] private Image image = null;

    private CharacterData characterData;

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetName(characterData.name);
        SetImage(characterData.image);
    }

    public void SetName(string name)
    {
        if (name != null)
        {
            characterName.text = name;
        }
        else
        {
            Debug.Log("No Name");
        }
    }

    public void SetImage(Sprite sprite)
    {
        if (sprite != null)
        {
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("No Image");
        }
    }

    public override void OnShow()
    {
        characterName.text = characterData.name;

        base.OnShow();
    }
}
