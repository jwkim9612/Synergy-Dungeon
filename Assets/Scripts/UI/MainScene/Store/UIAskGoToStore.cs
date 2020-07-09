using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAskGoToStore : UIControl
{
    [SerializeField] private Text titleText = null;
    [SerializeField] private Text contentText = null;
    [SerializeField] private Button cancelButton = null;
    [SerializeField] private Button goToStoreButton = null;

    [SerializeField] private SimpleScrollSnap simpleScrollSnap = null;
    [SerializeField] private RectTransform goldGoods = null;
    [SerializeField] private RectTransform diamondGoods = null;
    [SerializeField] private RectTransform HeartGoods = null;
    private RectTransform target;

    private void Start()
    {
        cancelButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
        });

        goToStoreButton.onClick.AddListener(() =>
        {
            simpleScrollSnap.GoToPanel(MainService.INDEX_OF_STORE);
            MainManager.instance.uiStore.scrollView.GoToTarget(target);
            UIManager.Instance.HideAndShowPreview();
        });
    }

    public void SetText(PurchaseCurrency purchaseCurrency)
    {
        switch (purchaseCurrency)
        {
            case PurchaseCurrency.Gold:
                titleText.text = "골드 부족!";
                contentText.text = "골드가 부족합니다. 상점에서 더 구매하세요!";
                target = goldGoods;
                break;
            case PurchaseCurrency.Diamond:
                titleText.text = "보석 부족!";
                contentText.text = "보석이 부족합니다. 상점에서 더 구매하세요!";
                target = diamondGoods;
                break;
            case PurchaseCurrency.Heart:
                titleText.text = "하트 부족!";
                contentText.text = "하트가 부족합니다. 상점에서 더 구매하세요!";
                target = HeartGoods;
                break;
            default:
                Debug.LogError("Error UIAskGoToStore SetText");
                break;
        }
    }
}
