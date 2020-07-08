using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private GameObject beingPurchase = null;
    [SerializeField] private UIFloatingText purchaseCompletedFloatingText = null;
    [SerializeField] private UIFloatingText soldOutFloatingText = null;
    [SerializeField] private UIGoldSalesList uiGoldSalesList = null;
    [SerializeField] private UIRandomRuneSalesList uiRandomRuneSalesList = null;
    [SerializeField] private UIRandomPotionSalesList uiRandomPotionSalesList = null;
    [SerializeField] private UIHeartSalesList uiHeartSalesList = null;
    public UIRuneOnSalesList uiRuneOnSalesList = null;
    public UIObtainedRunesScreen uiObtainedRunesScreen;
    public UIObtainedRuneScreen uiObtainedRuneScreen;
    public PotentialDraggableScrollView scrollView;


    [SerializeField] private Button cheatGoldButton = null;
    [SerializeField] private Button cheatDiamondButton = null;

    private void Start()
    {
        uiRuneOnSalesList.Initialize();
        uiGoldSalesList.Initialize();
        uiRandomRuneSalesList.Initialize();
        uiRandomPotionSalesList.Initialize();
        uiHeartSalesList.Initialize();
        uiObtainedRunesScreen.Initialize();
        purchaseCompletedFloatingText.Initialize();
        soldOutFloatingText.Initialize();

        cheatGoldButton.onClick.AddListener(() =>
        {
            PlayerDataManager.Instance.playerData.Gold += 1000;
            PlayerDataManager.Instance.SavePlayerDataForCheat();
        });

        cheatDiamondButton.onClick.AddListener(() =>
        {
            PlayerDataManager.Instance.playerData.Diamond += 1000;
            PlayerDataManager.Instance.SavePlayerDataForCheat();
        });

        var aa = GetComponentsInChildren<UIGoods>().ToList();

        Debug.Log($"aa = count = {aa.Count}");
    }

    public void ShowBeingPurchase()
    {
        beingPurchase.SetActive(true);
    }

    public void HideBeginPurchase()
    {
        beingPurchase.SetActive(false);
    }

    public void PlayPurchaseCompletedFloatingText()
    {
        purchaseCompletedFloatingText.Play();
    }

    public void PlaySoldOutFloatingText()
    {
        soldOutFloatingText.Play();
    }
}
