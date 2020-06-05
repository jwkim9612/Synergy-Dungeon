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
        RewardCurrency = goodsExcelData.RewardCurrency;
        RewardAmount = goodsExcelData.RewardAmount;

        Image = Resources.Load<Sprite>(goodsExcelData.ImagePath);
    }

    public string Name;
    public PurchaseCurrency PurchaseCurrency;
    public int PurchasePrice;
    public RewardCurrency RewardCurrency;
    public int RewardAmount;
    public Sprite Image;
}
