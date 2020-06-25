using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRandomPotionSalesList : MonoBehaviour
{
    private UIRandomPotionGoods uiRandomPotionGoods;

    public void Initialize()
    {
        uiRandomPotionGoods = GetComponentInChildren<UIRandomPotionGoods>();
        var randomPotionSalesId = GoodsService.RANDOM_POTION_SALES_ID;

        var goodsDataSheet = DataBase.Instance.goodsDataSheet;
        if(goodsDataSheet == null)
        {
            Debug.LogError("Error goodsDataSheet is null!!");
            return;
        }

        if(goodsDataSheet.TryGetGoodsData(randomPotionSalesId, out var goodsData))
        {
            uiRandomPotionGoods.SetUIGoods(goodsData, randomPotionSalesId);
        }
    }
}
