using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipRune : UIRune
{
    [SerializeField] private UIOwnedRunes uiOwnedRunes = null;
    [SerializeField] private Button releaseButton = null;

    private void Start()
    {
        releaseButton.onClick.AddListener(() =>
        {
            if (rune != null)
            {
                SaveManager.Instance.SetEquippedRuneIdsSaveDataByRelease(rune.runeData.SocketPosition);
                SaveManager.Instance.SaveEquippedRuneIds();
                RuneManager.Instance.RemoveEquippedRune(rune.runeData.SocketPosition);
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
