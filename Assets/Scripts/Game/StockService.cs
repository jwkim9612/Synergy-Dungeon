using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class StockService
{
    //public Dictionary<Tier, Stock> Stocks { get; set; } = new Dictionary<Tier, Stock>();
    public Dictionary<Tier, Stock> Stocks { get; set; }

    public void Initialize()
    {
        Stocks = new Dictionary<Tier, Stock>();

        Stock oneTierStock = new Stock();
        Stock twoTierStock = new Stock();
        Stock threeTierStock = new Stock();
        Stock fourTierStock = new Stock();
        Stock fiveTierStock = new Stock();

        var characterDatas = GameManager.instance.dataSheet.characterDataSheet.characterDatas;

        foreach(var characterData in characterDatas)
        {
            for (int i = 0; i < CardService.MAX_NUM_OF_CARDS_PER_CHARACTER; ++i)
            {
                switch (characterData.Tier)
                {
                    case Tier.One:
                        oneTierStock.stockIds.Add(characterData.Id);
                        break;
                    case Tier.Two:
                        twoTierStock.stockIds.Add(characterData.Id);
                        break;
                    case Tier.Three:
                        threeTierStock.stockIds.Add(characterData.Id);
                        break;
                    case Tier.Four:
                        fourTierStock.stockIds.Add(characterData.Id);
                        break;
                    case Tier.Five:
                        fiveTierStock.stockIds.Add(characterData.Id);
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

        stockId = Random.Range(0, stock.stockIds.Count);
        randomId = stock.stockIds[stockId];

        RemoveStockId(randomId);

        return randomId;
    }

    public void RemoveStockId(int stockId)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[stockId].Tier];

        stock.stockIds.Remove(stockId);
    }

    public void RemoveStockId(CharacterInfo characterInfo)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[characterInfo.id].Tier];

        int numOfAdditions = GetNumOfCharactersPerStar(characterInfo.star);

        for (int i = 0; i < numOfAdditions; ++i)
        {
            stock.stockIds.Remove(characterInfo.id);
        }
    }

    public void AddStockId(int stockId)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[stockId].Tier];

        stock.stockIds.Add(stockId);
    }

    public void AddStockId(CharacterInfo characterInfo)
    {
        var characterDatas = GameManager.instance.dataSheet.characterDataSheet.characterDatas;
        Stock stock = null;

        stock = Stocks[characterDatas[characterInfo.id].Tier];

        int numOfAdditions = GetNumOfCharactersPerStar(characterInfo.star);

        for(int i = 0; i < numOfAdditions; ++i)
        {
            stock.stockIds.Add(characterInfo.id);
        }
    }

    public int GetNumOfCharactersPerStar(int star)
    {
        int numOfCharacters = 0;

        switch (star)
        {
            case 1:
                numOfCharacters = 1;
                break;
            case 2:
                numOfCharacters = 3;
                break;
            case 3:
                numOfCharacters = 9;
                break;
            default:
                Debug.Log("Error AddStockId");
                break;
        }

        return numOfCharacters;
    }
}
