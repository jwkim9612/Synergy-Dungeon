using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRune : MonoBehaviour
{
    [SerializeField] private Image image;
    private RuneData runeData;
    private Rune rune;

    public void SetUIRune(RuneData newRuneData)
    {
        runeData = newRuneData;

        rune = new Rune();
        rune.SetRune(newRuneData);

        SetImage(runeData.Image);
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    
}
