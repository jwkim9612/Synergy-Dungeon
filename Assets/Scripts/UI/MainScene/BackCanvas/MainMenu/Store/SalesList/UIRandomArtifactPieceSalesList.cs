using UnityEngine;

public class UIRandomArtifactPieceSalesList : MonoBehaviour
{
    private UIRandomArtifactPieceGoods uiRandomArtifactPieceGoods;

    public void Initialize()
    {
        SetUIRandomArtifactPieceGoods();
    }

    private void SetUIRandomArtifactPieceGoods()
    {
        uiRandomArtifactPieceGoods = GetComponentInChildren<UIRandomArtifactPieceGoods>();

        var randomArtifactPieceSalesId = GoodsService.RANDOM_ARTIFACTPIECE_SALES_ID;

        var goodsDataSheet = DataBase.Instance.goodsDataSheet;
        if (goodsDataSheet.TryGetGoodsData(randomArtifactPieceSalesId, out var goodsData))
        {
            uiRandomArtifactPieceGoods.SetUIGoods(goodsData, randomArtifactPieceSalesId);
        }
    }
}
