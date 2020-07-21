﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipRune : UIRune
{
    [SerializeField] private Image backgroundImage;

    public override void SetUIRune(RuneData newRuneData)
    {
        base.SetUIRune(newRuneData);

        isEquippedRune = true;

        ShowImages();
        SetShowRuneInfoButtonInteractable(true);
    }

    public void Disable()
    {
        HideImages();
        rune = null;
        SetShowRuneInfoButtonInteractable(false);
    }

    private void HideImages()
    {
        runeImage.gameObject.SetActive(false);
        originImage.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(false);
    }

    private void ShowImages()
    {
        runeImage.gameObject.SetActive(true);
        originImage.gameObject.SetActive(true);
        backgroundImage.gameObject.SetActive(true);
    }
}
