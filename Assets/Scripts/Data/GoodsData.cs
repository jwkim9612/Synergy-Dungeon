using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsData
{
    public GoodsData(GoodsExcelData goodsExcelData)
    {
        Name = goodsExcelData.Name;
        PurchaseCurrency = goodsExcelData.PurchaseCurrency;
        PurchasePrice = goodsExcelData.PurchasePrice;
        RewardCurrencyType = goodsExcelData.RewardCurrencyType;
        RewardAmount = goodsExcelData.RewardAmount;

        Image = Resources.Load<Sprite>(goodsExcelData.ImagePath);
    }

    public string Name;
    public PurchaseCurrency PurchaseCurrency;
    public int PurchasePrice;
    public RewardCurrency RewardCurrencyType;
    public int RewardAmount;
    public Sprite Image;
}
