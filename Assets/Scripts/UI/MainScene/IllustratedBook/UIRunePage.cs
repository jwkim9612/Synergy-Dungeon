using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    public UIEquippedRunes uiEquippedRunes = null;
    public PotentialDraggableScrollView scrollView = null;
    public UIOwnedRunes uiOwnedRunes = null;
    public ToggleGroup toggleGroup = null;

    public void Initialize()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();
    }
}
