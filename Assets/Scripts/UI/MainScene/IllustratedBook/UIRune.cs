using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRune : MonoBehaviour
{
    [SerializeField] private Image unclickedImage;
    [SerializeField] private Image clickedImage;
    //public RuneData runeData;
    public Rune rune { get; set; }

    public void SetUIRune(RuneData newRuneData)
    {
        //runeData = newRuneData;

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
