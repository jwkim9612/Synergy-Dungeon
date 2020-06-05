using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GoodsExcelData
{
    public int Id;
    public string Name;
    public PurchaseCurrency PurchaseCurrency;
    public int PurchasePrice;
    public RewardCurrency RewardCurrencyType;
    public int RewardAmount;
    public string ImagePath;
}
