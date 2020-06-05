using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRandomRuneSalesList : MonoBehaviour
{
    private List<UIAmountRequiredGoods> uiRuneGoodsList;

    public void Initialize()
    {
        uiRuneGoodsList = GetComponentsInChildren<UIAmountRequiredGoods>().ToList();

        //uiRuneGoodsList[0].SetUIGoods(GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[GoodsService.FIRST_RUNE_SALES_ID], GoodsService.FIRST_RUNE_SALES_ID);
        //uiRuneGoodsList[1].SetUIGoods(GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[GoodsService.SECOND_RUNE_SALES_ID], GoodsService.SECOND_RUNE_SALES_ID);
    }
}
