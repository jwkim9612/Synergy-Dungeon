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
        Debug.Log("여기가 먼저되면 안됨");
        runeOnSalesList = GoodsManager.Instance.runeOnSalesList;
        uiRuneOnSalesList = GetComponentsInChildren<UIRuneGoods>().ToList();
        
        for(int i = 0; i < GoodsService.RUNE_SALES_ID_LIST.Count; ++i)
        {
            int goodsId = GoodsService.RUNE_SALES_ID_LIST[i];
            var goodsData = GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[goodsId];
            if (uiRuneOnSalesList == null)
                Debug.Log("uirunelist = null");
            if (runeOnSalesList == null)
                Debug.Log("runeList = null");

            uiRuneOnSalesList[i].SetUIGoods(goodsData, goodsId, runeOnSalesList[i].Item1);
        }
    }
}
