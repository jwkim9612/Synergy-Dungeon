using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObtainedRuneScreen : UIObtainedScreenWithDescription
{
    public override void SetUIObtainedScreen(int runeId)
    {
        var runeDataSheet = DataBase.Instance.runeDataSheet;
        if (runeDataSheet == null)
        {
            Debug.LogError("Error runeDataSheet is null");
            return;
        }

        if (runeDataSheet.TryGetRuneData(runeId, out var runeData))
        {
            SetGoodsImage(runeData.Image);
            SetGoodsName(runeData.Name);
            SetGoodsDescription(runeData.Description);
            SetRuneGrade(runeData.Grade);
        }
    }
    private void SetRuneGrade(RuneGrade runeGrade)
    {
        this.goodsGrade.text = RuneService.GetNameStrByGrade(runeGrade);
    }
}
