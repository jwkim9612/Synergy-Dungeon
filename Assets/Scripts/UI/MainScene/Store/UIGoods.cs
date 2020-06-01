using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoods : MonoBehaviour
{
    [SerializeField] private UIAskBuyIt uiAskBuyIt;
    [SerializeField] private Button showAskBuyItButton;
    [SerializeField] private Text goodsName;
    [SerializeField] private Text goodsAmount;
    [SerializeField] private Image goodsImage;
    [SerializeField] private Text goodsPrice;
    [SerializeField] private Image purchaseCurrencyImage;

    public void SetUIGoods(GoodsData goodsData, int goodsId)
    {
        SetGoodsName(goodsData.Name);
        SetGoodsAmount(goodsData.RewardAmount);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);

        showAskBuyItButton.onClick.AddListener(() =>
        {
            uiAskBuyIt.SetUIAskItBuy(goodsData, goodsId);
            UIManager.Instance.ShowNew(uiAskBuyIt);
        });
    }

    private void SetGoodsName(string name)
    {
        goodsName.text = name;
    }

    private void SetGoodsAmount(int amount)
    {
        goodsAmount.text = amount.ToString();
    }

    private void SetPurchaseCurrencyImage(PurchaseCurrency purchaseCurrency)
    {
        switch(purchaseCurrency)
        {
            case PurchaseCurrency.Gold:
                purchaseCurrencyImage.sprite = GoodsService.GOLD_IMAGE;
                break;
            case PurchaseCurrency.Diamond:
                purchaseCurrencyImage.sprite = GoodsService.DIAMOND_IMAGE;
                break;
        }
    }

    private void SetGoodsPrice(int price)
    {
        goodsPrice.text = price.ToString();
    }

    private void SetGoodsImage(Sprite image)
    {
        goodsImage.sprite = image;
    }
}
