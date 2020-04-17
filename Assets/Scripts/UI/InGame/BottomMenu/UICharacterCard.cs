using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterCard : MonoBehaviour
{
    [SerializeField] public Image characterImage;
    [SerializeField] private Text priceText;
    [SerializeField] private Image tribeImage;
    [SerializeField] private Text tribeText;
    [SerializeField] private Image originImage;
    [SerializeField] private Text originText;
    [SerializeField] private Text characterNameText;
    [SerializeField] private Image costBorderImage;

    private CharacterData characterData;
    public void SetCard(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        characterImage.sprite = characterData.image;
        priceText.text = ((int)(characterData.cost)).ToString();
        tribeImage.sprite = characterData.tribeData.Sheet[characterData.tribeData.idxList[0]].image;
        tribeText.text = characterData.tribeData.Sheet[characterData.tribeData.idxList[0]].strTribe;
        originImage.sprite = characterData.originData.Sheet[characterData.originData.idxList[0]].image;
        originText.text = characterData.originData.Sheet[characterData.originData.idxList[0]].strOrigin;
        characterNameText.text = characterData.name;
        costBorderImage.color = characterData.colorCost;
    }
}
