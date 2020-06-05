using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRuneOnSalesList : MonoBehaviour
{
    private List<UIRuneGoods> uiRuneOnSalesList;
    public List<Tuple<int, bool>> runeOnSalesList;

    public void Initialize()
    {
        runeOnSalesList = GoodsManager.Instance.runeOnSalesList;
        uiRuneOnSalesList = GetComponentsInChildren<UIRuneGoods>().ToList();
        
        for(int index = 0; index < GoodsService.RUNE_SALES_ID_LIST.Count; ++index)
        {
            int goodsId = GoodsService.RUNE_SALES_ID_LIST[index];
            var goodsData = GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[goodsId];

            uiRuneOnSalesList[index].SetUIGoods(goodsData, goodsId, runeOnSalesList[index].Item1, index);
        }
    }
}
