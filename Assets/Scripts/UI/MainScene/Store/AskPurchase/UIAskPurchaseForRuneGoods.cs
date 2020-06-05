using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAskPurchaseForRuneGoods : UIAskPurchase
{
    private int runeOnSalesIndex;
    private RuneGrade runeGrade;

    private new void Start()
    {
        base.Start();

        purchaseButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
            GoodsManager.Instance.PurchaseGoods(goodsId, runeOnSalesIndex, runeGrade);
        });
    }

    public void SetUIAskPurchase(GoodsData goodsData, int goodsId, RuneData runeData, int salesIndex)
    {
        SetAskPurchaseText(runeData.Name);
        SetGoodsImage(runeData.Image);
        SetGoodsPrice(goodsData.PurchasePrice, goodsData.PurchaseCurrency);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);
        SetRuneGrade(runeData.Grade);
        runeOnSalesIndex = salesIndex;

        this.goodsId = goodsId;
    }

    private void SetRuneGrade(RuneGrade runeGrade)
    {
        this.runeGrade = runeGrade;
    }
}
