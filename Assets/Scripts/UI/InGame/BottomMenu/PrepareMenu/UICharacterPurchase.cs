using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterPurchase : MonoBehaviour
{
    [SerializeField] private UICharacterCard[] cards = null;
    public StockService stockService { get; set; } = null;
    public ProbabilityService probabilityService { get; set; } = null;

    void Start()
    {
        stockService = InGameManager.instance.stockService;
        probabilityService = InGameManager.instance.probabilityService;

        foreach(var card in cards)
        {
            card.isBoughtCard = true;
        }

        Shuffle();
        InGameManager.instance.gameState.OnPrepare += Shuffle;
    }

    // 카드 섞기
    public void Shuffle()
    {
        foreach(var card in cards)
        {
            if (!(card.isBoughtCard))
            {
                int cardId = card.characterData.Id;
                stockService.AddStockId(cardId);
            }

            Tier randomTier = probabilityService.GetRandomTier();
            int randomId = stockService.GetRandomId(randomTier);
            card.SetCard(GameManager.instance.dataSheet.characterDataSheet.characterDatas[randomId]);
            card.UpdateBuyable();
            card.OnShow();
            card.isBoughtCard = false;
        }
    }
}
