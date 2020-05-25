using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRunePage : MonoBehaviour
{
    [SerializeField] private UIOwnedRunes uiOwnedRunes;
    [SerializeField] private UIEquippedRunes uiEquippedRunes;

    private void Start()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();
    }
}
