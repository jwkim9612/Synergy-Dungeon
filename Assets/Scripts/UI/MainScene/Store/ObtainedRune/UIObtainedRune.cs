using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObtainedRune : MonoBehaviour
{
    [SerializeField] private Image runeImage;
    [SerializeField] private Text runeName;

    public void SetUIObtainedRune(int runeId)
    {
        var runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];
        
        SetRuneImage(runeData.Image);
        SetRuneName(runeData.Name);
    }

    private void SetRuneImage(Sprite sprite)
    {
        runeImage.sprite = sprite;
    }

    private void SetRuneName(string name)
    {
        runeName.text = name;
    }
}
