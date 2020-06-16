using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private GameObject beingPurchase = null;
    [SerializeField] private UIFloatingText purchaseCompletedFloatingText = null;
    [SerializeField] private UIFloatingText soldOutFloatingText = null;
    [SerializeField] private UIGoldSalesList uiGoldSalesList = null;
    [SerializeField] private UIRandomRuneSalesList uiRandomRuneSalesList = null;
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
        uiObtainedRunesScreen.Initialize();
        purchaseCompletedFloatingText.Initialize();

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
