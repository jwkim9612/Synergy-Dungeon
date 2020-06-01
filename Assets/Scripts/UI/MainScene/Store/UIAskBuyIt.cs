using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAskBuyIt : UIControl
{
    [SerializeField] private Text askBuyItText;
    [SerializeField] private Text goodsAmount;
    [SerializeField] private Image goodsImage;
    [SerializeField] private Text goodsPrice;
    [SerializeField] private Image purchaseCurrencyImage;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button cancelButton;
    private int goodsId;

    private void Start()
    {
        buyButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
            GoodsManager.Instance.BuyingGoods(goodsId);
        });

        cancelButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
        });
    }

    public void SetUIAskItBuy(GoodsData goodsData, int goodsId)
    {
        SetAskBuyItText(goodsData.Name);
        SetGoodsAmount(goodsData.RewardAmount);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice, goodsData.PurchaseCurrency);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);

        this.goodsId = goodsId;
    }

    private void SetAskBuyItText(string name)
    {
        askBuyItText.text = name + "를 구매하시겠습니까?";
    }

    private void SetGoodsAmount(int amount)
    {
        goodsAmount.text = amount.ToString();
    }

    private void SetPurchaseCurrencyImage(PurchaseCurrency purchaseCurrency)
    {
        switch (purchaseCurrency)
        {
            case PurchaseCurrency.Gold:
                purchaseCurrencyImage.sprite = GoodsService.GOLD_IMAGE;
                break;
            case PurchaseCurrency.Diamond:
                purchaseCurrencyImage.sprite = GoodsService.DIAMOND_IMAGE;
                break;
            default:
                Debug.LogError("Error SetPurchaseCurrencyImage!!");
                break;
        }
    }

    private void SetGoodsPrice(int price, PurchaseCurrency purchaseCurrency)
    {
        goodsPrice.text = price.ToString();

        switch (purchaseCurrency)
        {
            case PurchaseCurrency.Gold:
                {
                    if (price <= PlayerDataManager.Instance.playerData.Gold)
                        goodsPrice.color = Color.black;
                    else
                        goodsPrice.color = Color.red;
                }
                break;

            case PurchaseCurrency.Diamond:
                {
                    if (price <= PlayerDataManager.Instance.playerData.Diamond)
                        goodsPrice.color = Color.black;
                    else
                        goodsPrice.color = Color.red;
                }
                break;
            default:
                Debug.LogError("Error SetGoodsPrice!!");
                break;
        }
    }

    private void SetGoodsImage(Sprite image)
    {
        goodsImage.sprite = image;
    }
}
