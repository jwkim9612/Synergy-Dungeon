using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRandomRuneGoods : UIGoods
{
    [SerializeField] protected UIAskPurchaseForRandomRuneGoods uiAskPurchase;
    [SerializeField] private Text goodsAmount;

    public void SetUIGoods(GoodsData goodsData, int goodsId, RuneRating runeRating)
    {
        SetGoodsName(goodsData.Name);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);
        SetGoodsAmount(goodsData.RewardAmount);

        showAskBuyItButton.onClick.AddListener(() =>
        {
            uiAskPurchase.SetUIAskPurchase(goodsData, goodsId, runeRating);
            UIManager.Instance.ShowNew(uiAskPurchase);
        });
    }

    private void SetGoodsAmount(int amount)
    {
        goodsAmount.text = amount.ToString();
    }
}
