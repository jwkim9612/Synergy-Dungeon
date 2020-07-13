﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISynergy : MonoBehaviour
{
    [SerializeField] private Image synergyImage = null;
    [SerializeField] protected Toggle toggle = null;
    public UIInGameSynergyInfo uiInGameSynergyInfo { get; set; } = null;

    protected void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void SetImage(Sprite sprite)
    {
        synergyImage.sprite = sprite;
    }
}
