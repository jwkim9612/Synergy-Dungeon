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
                
                // 원래 아래함수였는데 AddUIRune으로 바꿈 오류있으면 다시 바꿀것.
                //uiOwnedRunes.AddUIRuneByEquipRelease(rune.runeData.Id);
                uiOwnedRunes.AddUIRune(rune.runeData.Id);
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
