using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDetailedSettings : MonoBehaviour
{
    delegate void OnDetailedSettingChangedDelegate();
    OnDetailedSettingChangedDelegate OnDetailedSettingChanged;

    [SerializeField] private UICharacterList characterList;
    [SerializeField] private Dropdown cost;
    [SerializeField] private Dropdown tribe;
    [SerializeField] private Dropdown origin;

    void Start()
    {
        OnDetailedSettingChanged = characterList.Sort;
    }

    public void OnCostValueChanged()
    {
        characterList.currentCost = (Cost)cost.value;
        OnDetailedSettingChanged();
    }

    public void OnTribeValueChanged()
    {
        characterList.currentTribe = (Tribe)tribe.value;
        OnDetailedSettingChanged();
    }

    public void OnOriginValueChanged()
    {
        characterList.currentOrigin = (Origin)origin.value;
        OnDetailedSettingChanged();
    }
}
