using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDetailedSettings : MonoBehaviour
{
    delegate void OnDetailedSettingChangedDelegate();
    OnDetailedSettingChangedDelegate OnDetailedSettingChanged { get; set; }

    [SerializeField] private UICharacterList characterList = null;
    [SerializeField] private Dropdown tier = null;
    [SerializeField] private Dropdown tribe = null;
    [SerializeField] private Dropdown origin = null;

    void Start()
    {
        OnDetailedSettingChanged += characterList.Sort;
    }

    public void OnCostValueChanged()
    {
        characterList.currentTier = (Tier)tier.value;
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
