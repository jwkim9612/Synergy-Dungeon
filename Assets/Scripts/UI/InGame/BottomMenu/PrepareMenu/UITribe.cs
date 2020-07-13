using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITribe : UISynergy
{
    Tribe tribe;

    private new void Start()
    {
        base.Start();

        toggle.onValueChanged.AddListener((bool bOn) =>
        {
            if (bOn)
            {
                uiInGameSynergyInfo.SetSynergyInfo(tribe);
                uiInGameSynergyInfo.OnShow();
            }
        });
    }

    public void SetTribe(Tribe newTribe)
    {
        tribe = newTribe;
    }
}
