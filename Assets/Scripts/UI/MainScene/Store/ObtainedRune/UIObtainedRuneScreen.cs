using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObtainedRuneScreen : UIControl
{
    [SerializeField] private UIObtainedRune uiObtainedRune = null;

    public void SetUIObtainedRune(int runeId)
    {
        uiObtainedRune.SetUIObtainedRune(runeId);
    }
}
