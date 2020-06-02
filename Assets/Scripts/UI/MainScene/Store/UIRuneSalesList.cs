using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRuneSalesList : MonoBehaviour
{
    private List<UIGoods> uiRuneGoodsList;

    public void Initialize()
    {
        uiRuneGoodsList = GetComponentsInChildren<UIGoods>().ToList();

        uiRuneGoodsList[0].SetUIGoods(GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[GoodsService.FIRST_RUNE_SALES_ID], GoodsService.FIRST_RUNE_SALES_ID);
        uiRuneGoodsList[1].SetUIGoods(GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[GoodsService.SECOND_RUNE_SALES_ID], GoodsService.SECOND_RUNE_SALES_ID);
    }
}
