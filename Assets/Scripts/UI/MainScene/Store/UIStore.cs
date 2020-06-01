using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private UIGoldSalesList uiGoldSalesList;
    public PotentialDraggableScrollView scrollView;


    private void Start()
    {
        uiGoldSalesList.Initialize();
    }
}
