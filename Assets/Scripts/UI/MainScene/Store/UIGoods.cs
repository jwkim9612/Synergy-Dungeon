using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoods : MonoBehaviour
{
    [SerializeField] protected Button showAskBuyItButton;
    [SerializeField] private Text goodsName;
    [SerializeField] private Image goodsImage;
    [SerializeField] private Text goodsPrice;
    [SerializeField] private Image purchaseCurrencyImage;

    protected void SetGoodsName(string name)
    {
        goodsName.text = name;
    }

    protected void SetPurchaseCurrencyImage(PurchaseCurrency purchaseCurrency)
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

    protected void SetGoodsPrice(int price)
    {
        goodsPrice.text = price.ToString();
    }

    protected void SetGoodsImage(Sprite image)
    {
        goodsImage.sprite = image;
    }
}
