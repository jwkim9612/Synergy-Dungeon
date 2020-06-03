using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private UIGoldSalesList uiGoldSalesList;
    [SerializeField] private UIRuneSalesList uiRuneSalesList;
    public UIObtainedRunesScreen uiObtainedRunesScreen;
    public UIObtainedRuneScreen uiObtainedRuneScreen;
    public PotentialDraggableScrollView scrollView;


    private void Start()
    {
        uiGoldSalesList.Initialize();
        uiRuneSalesList.Initialize();
        uiObtainedRunesScreen.Initialize();
    }
}
