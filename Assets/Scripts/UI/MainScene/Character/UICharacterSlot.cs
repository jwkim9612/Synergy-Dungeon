using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SharedService;
using geniikw.DataSheetLab;

public class UICharacterSlot : MonoBehaviour
{
    [SerializeField] private UICharacterInfo characterInfo = null;
    [SerializeField] private Text characterName = null;
    [SerializeField] private Image image = null;
    [SerializeField] private Image costBorder = null;
    
    public CharacterData characterData { get; set; }

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetName(characterData.name);
        SetImage(characterData.image);
        SetTierBorder(Card.GetColorByTier(characterData.tier));
    }

    public void SetName(string name)
    {
        if(name != null)
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
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("No Character Image");
        }
    }

    public void SetTierBorder(Color color)
    {
        costBorder.color = color;
    }

    public void OnClicked()
    {
        characterInfo.SetCharacterData(characterData);
        GameManager.instance.uiManager.ShowNew(characterInfo);
    }
}
