using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAskPurchaseForAmountRequiredGoods : UIAskPurchase
{
    [SerializeField] private Text goodsAmount;

    private new void Start()
    {
        base.Start();

        purchaseButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
            GoodsManager.Instance.PurchaseGoods(goodsId);
        });
    }

    public void SetUIAskPurchase(GoodsData goodsData, int goodsId)
    {
        SetAskPurchaseText(goodsData.Name);
        SetGoodsAmount(goodsData.RewardAmount);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice, goodsData.PurchaseCurrency);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);

        this.goodsId = goodsId;
    }

    private void SetGoodsAmount(int amount)
    {
        goodsAmount.text = amount.ToString();
    }
}
