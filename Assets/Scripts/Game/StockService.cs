using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharedService;
using geniikw.DataSheetLab;

public class StockService
{
    public Dictionary<Tier, Stock> Stocks = new Dictionary<Tier, Stock>();

    public void Initialize()
    {
        ClearAllStock();

        Stock oneTierStock = new Stock();
        Stock twoTierStock = new Stock();
        Stock threeTierStock = new Stock();
        Stock fourTierStock = new Stock();
        Stock fiveTierStock = new Stock();

        var characterDatas = GameManager.instance.dataSheet.characterDatas;

        foreach(var characterData in characterDatas)
        {
            for (int i = 0; i < Card.MAX_NUM_OF_CARDS_PER_CHARACTER; ++i)
            {
                switch (characterData.tier)
                {
                    case Tier.One:
                        oneTierStock.stockIds.Add(characterData.id);
                        break;
                    case Tier.Two:
                        twoTierStock.stockIds.Add(characterData.id);
                        break;
                    case Tier.Three:
                        threeTierStock.stockIds.Add(characterData.id);
                        break;
                    case Tier.Four:
                        fourTierStock.stockIds.Add(characterData.id);
                        break;
                    case Tier.Five:
                        fiveTierStock.stockIds.Add(characterData.id);
                        break;
                    default:
                        Debug.Log("Error InitializeStock");
                        break;
                }
            }
        }

        Stocks.Add(Tier.One, oneTierStock);
        Stocks.Add(Tier.Two, twoTierStock);
        Stocks.Add(Tier.Three, threeTierStock);
        Stocks.Add(Tier.Four, fourTierStock);
        Stocks.Add(Tier.Five, fiveTierStock);
    }


    public void ClearAllStock()
    {
        foreach (var stock in Stocks)
        {
            stock.Value.stockIds.Clear();
        }
    }

    public int GetRandomId(Tier tier)
    {
        Stock stock = null;
        int randomId;
        int stockId;

        stock = Stocks[tier];
        //SetStockByTier(ref stock, tier);

        stockId = Random.Range(0, stock.stockIds.Count);
        randomId = stock.stockIds[stockId];

        RemoveStockId(randomId);

        return randomId;
    }

    public void RemoveStockId(int stockId)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[stockId].tier];
        //SetStockByTier(ref stock, characterDatas[stockId].tier);

        stock.stockIds.Remove(stockId);
    }

    public void AddStockId(int stockId)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[stockId].tier];
        //SetStockByTier(ref stock, characterDatas[stockId].tier);

        stock.stockIds.Add(stockId);
    }

    //public Stock SetStockByTier(ref Stock stock, Tier tier)
    //{
    //    switch (tier)
    //    {
    //        case Tier.One:
    //            Stocks.TryGetValue(Tier.One, out stock);
    //            break;
    //        case Tier.Two:
    //            Stocks.TryGetValue(Tier.Two, out stock);
    //            break;
    //        case Tier.Three:
    //            Stocks.TryGetValue(Tier.Three, out stock);
    //            break;
    //        case Tier.Four:
    //            Stocks.TryGetValue(Tier.Four, out stock);
    //            break;
    //        case Tier.Five:
    //            Stocks.TryGetValue(Tier.Five, out stock);
    //            break;
    //        default:
    //            Debug.Log("Erro GetRandomId");
    //            stock = null;
    //            break;
    //    }

    //    return stock;
    //}
}
