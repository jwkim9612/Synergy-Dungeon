using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterSlot : MonoBehaviour
{
    [SerializeField] private UICharacterInfo characterInfo = null;
    [SerializeField] private Text characterName = null;
    [SerializeField] private Image characterImage = null;
    [SerializeField] private Image tribeImage = null;
    [SerializeField] private Image originImage = null;
    [SerializeField] private Image costBorder = null;
    
    public CharacterData characterData { get; set; }

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetName(characterData.Name);
        SetCharacterImage(characterData.Image);
        SetTribeImage(characterData.TribeData.Image);
        SetOriginImage(characterData.OriginData.Image);
        SetTierBorder(CardService.GetColorByTier(characterData.Tier));
    }

    public void SetName(string name)
    {
        if(name != "")
        {
            characterName.text = name;
        }
        else
        {
            Debug.Log("No Character Name");
        }
    }

    public void SetCharacterImage(Sprite sprite)
    {
        if (sprite != null)
        {
            characterImage.sprite = sprite;
        }
        else
        {
            Debug.Log("No Character Image");
        }
    }

    public void SetTribeImage(Sprite sprite)
    {
        if (sprite != null)
        {
            tribeImage.sprite = sprite;
        }
        else
        {
            Debug.Log("No tribe Image");
        }
    }

    public void SetOriginImage(Sprite sprite)
    {
        if (sprite != null)
        {
            originImage.sprite = sprite;
        }
        else
        {
            Debug.Log("No origin Image");
        }
    }

    public void SetTierBorder(Color color)
    {
        costBorder.color = color;
    }

    public void OnClicked()
    {
        characterInfo.SetCharacterData(characterData);
        UIManager.Instance.ShowNew(characterInfo);
    }
}
