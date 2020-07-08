using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIGoldSalesList : MonoBehaviour
{
    private List<UIAmountRequiredGoods> uiGoldGoodsList;

    public void Initialize()
    {
        uiGoldGoodsList = GetComponentsInChildren<UIAmountRequiredGoods>().ToList();

        SetUIGoldGoodsList();
    }

    public void SetUIGoldGoodsList()
    {
        var goldSalesIdList = GoodsService.GOLD_SALES_ID_LIST;

        var goodsDataSheet = DataBase.Instance.goodsDataSheet;
        if (goodsDataSheet == null)
        {
            Debug.LogError("Error goodsDataSheet is null");
            return;
        }

        for (int i = 0; i < goldSalesIdList.Count; ++i)
        {
            if (goodsDataSheet.TryGetGoodsData(goldSalesIdList[i], out var goodsData))
            {
                uiGoldGoodsList[i].SetUIGoods(goodsData, goldSalesIdList[i]);
            }
        }
    }
}
