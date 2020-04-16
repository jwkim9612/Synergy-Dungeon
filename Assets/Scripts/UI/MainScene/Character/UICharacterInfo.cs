using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterInfo : UIControl
{ 
    [SerializeField] private Text characterName = null;
    [SerializeField] private Image characterimage = null;

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
            Debug.Log("No Character Name");
        }
    }

    public void SetImage(Sprite sprite)
    {
        if (sprite != null)
        {
            characterimage.sprite = sprite;
        }
        else
        {
            Debug.Log("No Character Image");
        }
    }
}
