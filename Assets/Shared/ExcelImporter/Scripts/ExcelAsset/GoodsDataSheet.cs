using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class GoodsDataSheet : ScriptableObject
{
	public List<GoodsExcelData> GoodsExcelDatas;
    public Dictionary<int, GoodsData> GoodsDatas;

    public void Initialize()
    {
        InitializeGoodsDatas();
    }

    private void InitializeGoodsDatas()
    {
        GoodsDatas = new Dictionary<int, GoodsData>();

        foreach (var goodsExcelData in GoodsExcelDatas)
        {
            GoodsData goodsData = new GoodsData(goodsExcelData);
            GoodsDatas.Add(goodsExcelData.Id, goodsData);
        }
    }
}
