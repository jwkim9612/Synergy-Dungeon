using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharedService;

public class UICharacterPurchase : MonoBehaviour
{
    [SerializeField] private UICharacterCard[] cards = null;
    public StockService stockService = null;

    void Start()
    {
        stockService = GameManager.instance.inGameManager.stockService;

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
                Debug.Log("In ! isboughtcard");
                int cardId = card.characterData.id;
                stockService.AddStockId(cardId);
            }

            int id = stockService.GetRandomId(Tier.One);
            card.SetCard(GameManager.instance.characterManager.characterDatas[id]);
            card.isBoughtCard = false;
        }
    }
}
