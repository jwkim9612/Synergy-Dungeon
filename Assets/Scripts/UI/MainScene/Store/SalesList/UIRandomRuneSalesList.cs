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
        for (int i = 0; i < randomRuneIdAndRatingList.Count; ++i)
        {
            uiRadomRuneGoodsList[i].SetUIGoods(GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[randomRuneIdAndRatingList[i].Item1], randomRuneIdAndRatingList[i].Item1, randomRuneIdAndRatingList[i].Item2);
        }
    }
}
