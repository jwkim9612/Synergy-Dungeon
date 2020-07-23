using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRuneOnRunePage : UIRuneForRunePage
{
    public override void SetUIRune(RuneData newRuneData)
    {
        base.SetUIRune(newRuneData);

        isEquippedRune = false;
    }
}