﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGold : MonoBehaviour
{
    [SerializeField] private Text goldText = null;

    public void Initialize()
    {
        PlayerDataManager.Instance.OnGoldChanged += UpdateGoldText;
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        goldText.text = string.Format("{0}", PlayerDataManager.Instance.playerData.Gold.ToString("#,##0"));
    }
}