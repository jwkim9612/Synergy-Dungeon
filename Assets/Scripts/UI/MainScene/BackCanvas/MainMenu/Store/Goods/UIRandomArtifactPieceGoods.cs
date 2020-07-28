public class UIRandomArtifactPieceGoods : UIGoods
{
    public void SetUIGoods(GoodsData goodsData, int goodsId)
    {
        SetGoodsName(goodsData.Name);
        SetGoodsImage(goodsData.Image);
        SetGoodsPrice(goodsData.PurchasePrice);
        SetPurchaseCurrencyImage(goodsData.PurchaseCurrency);

        showAskPurchaseButton.onClick.AddListener(() =>
        {
            var uiAskPurchaseForRandomArtifactPieceGoods = MainManager.instance.backCanvas.uiMainMenu.uiStore.uiAskPurchaseForRandomArtifactPieceGoods;
            uiAskPurchaseForRandomArtifactPieceGoods.SetUIAskPurchase(goodsData, goodsId);
            UIManager.Instance.ShowNew(uiAskPurchaseForRandomArtifactPieceGoods);
        });
    }
}
