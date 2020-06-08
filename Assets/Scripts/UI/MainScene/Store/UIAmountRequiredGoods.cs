using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmountRequiredGoods : UIGoods
{
    [SerializeField] protected UIAskPurchaseForAmountRequiredGoods uiAskPurchase = null;
    [SerializeField] private Text goodsAmount = null;

    public void SetUIGoods(GoodsData goodsData, int goodsId)
    {
        SetGoodsName(goodsData.Name);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);
        SetGoodsAmount(goodsData.RewardAmount);

        showAskBuyItButton.onClick.AddListener(() =>
        {
            uiAskPurchase.SetUIAskPurchase(goodsData, goodsId);
            UIManager.Instance.ShowNew(uiAskPurchase);
        });
    }

    private void SetGoodsAmount(int amount)
    {
        goodsAmount.text = amount.ToString();
    }
}
