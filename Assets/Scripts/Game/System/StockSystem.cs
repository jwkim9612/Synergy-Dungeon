using System.Collections.Generic;
using UnityEngine;

public class StockSystem
{
    //public Dictionary<Tier, Stock> Stocks { get; set; } = new Dictionary<Tier, Stock>();
    public Dictionary<Tier, Stock> Stocks { get; set; }
    private CharacterDataSheet characterDataSheet;

    public void Initialize()
    {
        Stocks = new Dictionary<Tier, Stock>();

        Stock oneTierStock = new Stock();
        Stock twoTierStock = new Stock();
        Stock threeTierStock = new Stock();
        Stock fourTierStock = new Stock();
        Stock fiveTierStock = new Stock();

        characterDataSheet = DataBase.Instance.characterDataSheet;
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if(characterDataSheet.TryGetCharacterDatas(out var characterDatas))
        {
            foreach (var characterData in characterDatas)
            {
                for (int i = 0; i < CardService.MAX_NUM_OF_CARDS_PER_CHARACTER; ++i)
                {
                    switch (characterData.Value.Tier)
                    {
                        case Tier.One:
                            oneTierStock.stockIds.Add(characterData.Key);
                            break;
                        case Tier.Two:
                            twoTierStock.stockIds.Add(characterData.Key);
                            break;
                        case Tier.Three:
                            threeTierStock.stockIds.Add(characterData.Key);
                            break;
                        case Tier.Four:
                            fourTierStock.stockIds.Add(characterData.Key);
                            break;
                        case Tier.Five:
                            fiveTierStock.stockIds.Add(characterData.Key);
                            break;
                        default:
                            Debug.Log("Error InitializeStock");
                            break;
                    }
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
        if(characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterTier(stockId, out var tier))
        {
            Stock stock = null;
            stock = Stocks[tier];
            stock.stockIds.Remove(stockId);
        }
    }

    public void RemoveStockId(CharacterInfo characterInfo)
    {
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterTier(characterInfo.id, out var tier))
        {
            Stock stock = null;
            stock = Stocks[tier];

            int numOfAdditions = GetNumOfCharactersPerStar(characterInfo.star);

            for (int i = 0; i < numOfAdditions; ++i)
            {
                stock.stockIds.Remove(characterInfo.id);
            }
        }
    }

    public void AddStockId(int stockId)
    {
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterTier(stockId, out var tier))
        {
            Stock stock = null;
            stock = Stocks[tier];
            stock.stockIds.Add(stockId);
        }
    }

    public void AddStockId(CharacterInfo characterInfo)
    {
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterTier(characterInfo.id, out var tier))
        {
            Stock stock = null;
            stock = Stocks[tier];

            int numOfAdditions = GetNumOfCharactersPerStar(characterInfo.star);

            for (int i = 0; i < numOfAdditions; ++i)
            {
                stock.stockIds.Add(characterInfo.id);
            }
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
