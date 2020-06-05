using UnityEngine;
using UnityEngine.UI;

public class UIRuneGoods : UIGoods
{
    [SerializeField] protected UIAskPurchaseForRuneGoods uiAskPurchase;
    [SerializeField] private Text goodsGrade;
    private int runeOnSalesIndex;

    public void SetUIGoods(GoodsData goodsData, int goodsId, int runeId, int index)
    {
        var runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        SetGoodsName(runeData.Name);
        SetGoodsImage(runeData.Image);
        SetGoodsGrade(runeData.Grade);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);
        runeOnSalesIndex = index;

        showAskBuyItButton.onClick.AddListener(() =>
        {
            uiAskPurchase.SetUIAskPurchase(goodsData, goodsId, runeData, runeOnSalesIndex);
            UIManager.Instance.ShowNew(uiAskPurchase);
        });
    }

    public void SetGoodsGrade(RuneGrade runeGrade)
    {
        goodsGrade.text = RuneService.GetNameStrByGrade(runeGrade);
    }
}
