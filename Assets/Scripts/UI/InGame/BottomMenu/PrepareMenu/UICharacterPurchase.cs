using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterPurchase : MonoBehaviour
{
    [SerializeField] private UICharacterCard[] cards = null;
    public StockService stockService { get; set; } = null;
    public ProbabilityService probabilityService { get; set; } = null;
    [SerializeField] private Button cheatPurchaseCharacter = null;

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

    public void CheatPurchaseCharacter(int id)
    {
        CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(id);

        if (InGameManager.instance.combinationService.IsUpgradable(characterInfo))
        {
            BuyCharacter(id);
        }
        else
        {
            var emptyUICharacter = InGameManager.instance.draggableCentral.uiPrepareArea.GetEmptyUICharacter();
            if (emptyUICharacter == null)
            {
                Debug.Log("uiCharacter is full");
            }
            else
            {
                emptyUICharacter.SetCharacter(characterInfo);
                BuyCharacter(id);
            }
        }
    }

    private void BuyCharacter(int id)
    {


        CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(id);
        CharacterData characterData = GameManager.instance.dataSheet.characterDataSheet.characterDatas[id];

        InGameManager.instance.combinationService.AddCharacter(characterInfo);
        InGameManager.instance.playerState.UseCoin(CardService.GetPriceByTier(characterData.Tier));
    }
}
