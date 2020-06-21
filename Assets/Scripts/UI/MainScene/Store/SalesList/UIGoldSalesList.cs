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

        //uiGoldGoodsList[0].SetUIGoods(DataBase.Instance.goodsDataSheet.GoodsDatas[GoodsService.FIRST_GOLD_SALES_ID], GoodsService.FIRST_GOLD_SALES_ID);
        //uiGoldGoodsList[1].SetUIGoods(DataBase.Instance.goodsDataSheet.GoodsDatas[GoodsService.SECOND_GOLD_SALES_ID], GoodsService.SECOND_GOLD_SALES_ID);
        //uiGoldGoodsList[2].SetUIGoods(DataBase.Instance.goodsDataSheet.GoodsDatas[GoodsService.THIRD_GOLD_SALES_ID], GoodsService.THIRD_GOLD_SALES_ID);
    }
}
