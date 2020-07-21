using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRune : UIRune
{
    public override void SetUIRune(RuneData newRuneData)
    {
        base.SetUIRune(newRuneData);

        isEquippedRune = false;
    }
}