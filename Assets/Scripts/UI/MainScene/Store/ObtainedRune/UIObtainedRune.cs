using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObtainedRune : MonoBehaviour
{
    [SerializeField] private Image runeImage = null;
    [SerializeField] private Text runeName = null;
    [SerializeField] private Text runeGrade = null;

    public void SetUIObtainedRune(int runeId)
    {
        var runeDataSheet = DataBase.Instance.runeDataSheet;
        if (runeDataSheet == null)
        {
            Debug.LogError("Error runeDataSheet is null");
            return;
        }

        if(runeDataSheet.TryGetRuneData(runeId, out var runeData))
        {
            SetRuneImage(runeData.Image);
            SetRuneName(runeData.Name);
            SetRuneGrade(runeData.Grade);
        }
    }

    private void SetRuneImage(Sprite sprite)
    {
        runeImage.sprite = sprite;
    }

    private void SetRuneName(string name)
    {
        runeName.text = name;
    }

    private void SetRuneGrade(RuneGrade runeGrade)
    {
        this.runeGrade.text = RuneService.GetNameStrByGrade(runeGrade);
    }
}
