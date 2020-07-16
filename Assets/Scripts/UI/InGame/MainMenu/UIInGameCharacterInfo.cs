using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameCharacterInfo : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Text nameText;
    [SerializeField] private Image tribeImage;
    [SerializeField] private Image originImage;




    private void SetCharacterImage(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }

    private void SetNameText(string name)
    {
        nameText.text = name;
    }

    private void SetTribeImage(Sprite sprite)
    {
        tribeImage.sprite = sprite;
    }

    private void SetOriginImage(Sprite sprite)
    {
        originImage.sprite = sprite;
    }
}
