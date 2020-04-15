using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        SetCostBorder(characterData.cost);
    }

    public void SetName(string name)
    {
        if(name != null)
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

    public void SetCostBorder(Cost cost)
    {
        switch (cost)
        {
            case Cost.One:
                costBorder.color = Color.gray;
                break;
            case Cost.Two:
                costBorder.color = Color.green;
                break;
            case Cost.Three:
                costBorder.color = Color.blue;
                break;
            case Cost.Four:
                costBorder.color = Color.red;
                break;
            case Cost.Five:
                costBorder.color = Color.yellow;
                break;
            default:
                Debug.Log("Error SetCostBorder");
                break;
        }
    }

    public void OnClicked()
    {
        characterInfo.SetCharacterData(characterData);
        GameManager.instance.uiManager.ShowNew(characterInfo);
    }
}
