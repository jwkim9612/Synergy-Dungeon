using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRune : MonoBehaviour
{
    [SerializeField] private Image unclickedImage = null;
    [SerializeField] private Image clickedImage = null;
    public Rune rune { get; set; }

    public void SetUIRune(RuneData newRuneData)
    {
        rune = new Rune();
        rune.SetRune(newRuneData);

        SetImage(newRuneData.Image);
    }

    public void SetImage(Sprite sprite)
    {
        unclickedImage.sprite = sprite;
        clickedImage.sprite = sprite;
    }

    
}
