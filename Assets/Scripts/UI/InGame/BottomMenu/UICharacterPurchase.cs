using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharedService;

public class UICharacterPurchase : MonoBehaviour
{
    [SerializeField] private UICharacterCard[] cards = null;
    public StockService stockService = null;
    public ProbabilityService probabilityService = null;

    void Start()
    {
        stockService = GameManager.instance.stockService;
        probabilityService = GameManager.instance.probabilityService;

        foreach(var card in cards)
        {
            card.isBoughtCard = true;
        }

        Shuffle();
    }

    public void Shuffle()
    {
        foreach(var card in cards)
        {
            if (!(card.isBoughtCard))
            {
                int cardId = card.characterData.id;
                stockService.AddStockId(cardId);
            }

            Tier randomTier = probabilityService.GetRandomTier();
            int randomId = stockService.GetRandomId(randomTier);
            card.SetCard(GameManager.instance.characterManager.characterDatas[randomId]);
            card.isBoughtCard = false;
        }
    }
}
