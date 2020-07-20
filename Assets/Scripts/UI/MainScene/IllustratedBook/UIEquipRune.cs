using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipRune : UIRune
{
    public override void SetUIRune(RuneData newRuneData)
    {
        base.SetUIRune(newRuneData);

        isEquippedRune = true;
        SetShowRuneInfoButtonInteractable(true);
    }

    public void Disable()
    {
        SetImage(null);
        rune = null;
        SetShowRuneInfoButtonInteractable(false);
    }
}
