using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAskGoToStore : UIControl
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text contentText;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button goToStoreButton;

    [SerializeField] private SimpleScrollSnap simpleScrollSnap;
    [SerializeField] private RectTransform goldGoods;
    [SerializeField] private RectTransform diamondGoods;
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
            default:
                Debug.LogError("Error UIAskGoToStore SetText");
                break;
        }
    }
}
