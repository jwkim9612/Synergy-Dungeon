using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRuneGoods : UIGoods
{
    [SerializeField] protected UIAskPurchaseForRuneGoods uiAskPurchase;
    private int runeOnSalesIndex;

    public void SetUIGoods(GoodsData goodsData, int goodsId, int runeId, int index)
    {
        var runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        SetGoodsName(runeData.Name);
        SetGoodsImage(runeData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);
        runeOnSalesIndex = index;

        showAskBuyItButton.onClick.AddListener(() =>
        {
            uiAskPurchase.SetUIAskPurchase(goodsData, goodsId, runeData, runeOnSalesIndex);
            UIManager.Instance.ShowNew(uiAskPurchase);
        });
    }
}
