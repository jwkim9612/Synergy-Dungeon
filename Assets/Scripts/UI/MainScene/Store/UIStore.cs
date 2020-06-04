using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private UIRuneOnSalesList uiRuneOnSalesList;
    [SerializeField] private UIGoldSalesList uiGoldSalesList;
    [SerializeField] private UIRandomRuneSalesList uiRandomRuneSalesList;
    public UIObtainedRunesScreen uiObtainedRunesScreen;
    public UIObtainedRuneScreen uiObtainedRuneScreen;
    public PotentialDraggableScrollView scrollView;


    private void Start()
    {
        uiRuneOnSalesList.Initialize();
        uiGoldSalesList.Initialize();
        uiRandomRuneSalesList.Initialize();
        uiObtainedRunesScreen.Initialize();
    }
}
