using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRuneOnSalesList : MonoBehaviour
{
    private Dictionary<int, UIRuneGoods> uiRuneOnSalesList;
    //private List<UIRuneGoods> uiRuneOnSalesList;
    /// <summary>
    /// item1은 룬 id, item2는 팔렸는지에 대한 여부
    /// </summary>
    public List<Tuple<int, bool>> runeOnSalesList;

    public void Initialize()
    {
        uiRuneOnSalesList = new Dictionary<int, UIRuneGoods>();

        runeOnSalesList = GoodsManager.Instance.runeOnSalesList;
        var uiRuneGoods = GetComponentsInChildren<UIRuneGoods>().ToList();

        var runePurchaseableLevelDatas = GameManager.instance.dataSheet.runePurchaseableLevelDataSheet.RunePurchaseableLevelDatas;
        int listIndex = 0;

        for(int id = GoodsService.FIRST_RUNE_SALES_ID; id <= runePurchaseableLevelDatas.Count; ++id)
        {
            uiRuneOnSalesList.Add(id, uiRuneGoods[listIndex]);

            int goodsId = id;
            var goodsData = GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[goodsId];

            uiRuneOnSalesList[id].SetUIGoods(goodsData, goodsId, runeOnSalesList[listIndex].Item1, goodsId, runeOnSalesList[listIndex].Item2);
            ++listIndex;
        }
    }

    public void SetIsSoldOutToId(int id)
    {
        uiRuneOnSalesList[id].SetIsSoldOut();
    }
}
