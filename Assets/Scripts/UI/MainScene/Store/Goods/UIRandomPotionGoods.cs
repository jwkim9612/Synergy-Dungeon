using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRandomPotionGoods : UIGoods
{
    [SerializeField] protected UIAskPurchaseForRandomPotionGoods uiAskPurchase = null;

    public void SetUIGoods(GoodsData goodsData, int goodsId)
    {
        SetGoodsName(goodsData.Name);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);

        showAskPurchaseButton.onClick.AddListener(() =>
        {
            uiAskPurchase.SetUIAskPurchase(goodsData, goodsId, false);
            UIManager.Instance.ShowNew(uiAskPurchase);
        });
    }
}
