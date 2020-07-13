using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrigin : UISynergy
{
    Origin origin;

    private new void Start()
    {
        base.Start();

        toggle.onValueChanged.AddListener((bool bOn) =>
        {
            if (bOn)
            {
                uiInGameSynergyInfo.SetSynergyInfo(origin);
                uiInGameSynergyInfo.OnShow();
            }
        });
    }
    public void SetOrigin(Origin newOrigin)
    {
        origin = newOrigin;
    }
}
