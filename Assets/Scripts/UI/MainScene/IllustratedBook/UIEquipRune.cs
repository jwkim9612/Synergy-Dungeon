using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipRune : UIRune
{
    [SerializeField] private UIOwnedRunes uiOwnedRunes;
    [SerializeField] private Button releaseButton;

    private void Start()
    {
        releaseButton.onClick.AddListener(() =>
        {
            if (rune != null)
            {
                SaveManager.Instance.SetEquippedRuneIdsSaveDataByRelease(rune.runeData.SocketPosition);
                SaveManager.Instance.SaveEquippedRuneIds();
                uiOwnedRunes.AddUIRuneByEquipRelease(rune.runeData.Id);
                Disable();
            }
            else
            {
                Debug.Log("Error 장비 해제");
            }
        });
    }

    public void Disable()
    {
        SetImage(null);
        rune = null;
        DisableToggle();
    }

    private void DisableToggle()
    {
        Toggle toggle = GetComponent<Toggle>();
        toggle.isOn = false;
        toggle.interactable = false;
    }
}
