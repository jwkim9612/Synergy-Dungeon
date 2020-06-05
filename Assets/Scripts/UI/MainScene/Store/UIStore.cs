using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private GameObject beingPurchase = null;
    [SerializeField] private UIFloatingText purchaseCompletedFloatingText = null;
    [SerializeField] private UIRuneOnSalesList uiRuneOnSalesList = null;
    [SerializeField] private UIGoldSalesList uiGoldSalesList = null;
    [SerializeField] private UIRandomRuneSalesList uiRandomRuneSalesList = null;
    public UIObtainedRunesScreen uiObtainedRunesScreen;
    public UIObtainedRuneScreen uiObtainedRuneScreen;
    public PotentialDraggableScrollView scrollView;


    private void Start()
    {
        uiRuneOnSalesList.Initialize();
        uiGoldSalesList.Initialize();
        uiRandomRuneSalesList.Initialize();
        uiObtainedRunesScreen.Initialize();
        purchaseCompletedFloatingText.Initialize();
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
}
