using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRandomRuneSalesList : MonoBehaviour
{
    private List<UIRandomRuneGoods> uiRadomRuneGoodsList;

    public void Initialize()
    {
        uiRadomRuneGoodsList = GetComponentsInChildren<UIRandomRuneGoods>().ToList();

        var randomRuneIdAndRatingList = GoodsService.RANDOM_RUNE_SALES_ID_AND_RATING_LIST;
        var goodsDataSheet = DataBase.Instance.goodsDataSheet;
        if(goodsDataSheet == null)
        {
            Debug.LogError("Error goodsDataSheet is null");
            return;
        }
        
        for (int i = 0; i < randomRuneIdAndRatingList.Count; ++i)
        {
            if(goodsDataSheet.TryGetGoodsData(randomRuneIdAndRatingList[i].Item1, out var goodsData))
            {
                uiRadomRuneGoodsList[i].SetUIGoods(goodsData, randomRuneIdAndRatingList[i].Item1, randomRuneIdAndRatingList[i].Item2);
            }
        }
    }
}
