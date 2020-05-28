using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGold : MonoBehaviour
{
    [SerializeField] private Text goldText;

    public void Initialize()
    {
        PlayerDataManager.Instance.OnDiamondChanged += UpdateGoldText;
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        goldText.text = string.Format("{0}", PlayerDataManager.Instance.playerData.Gold.ToString("#,##0"));
    }
}
