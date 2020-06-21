using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterPurchase : MonoBehaviour
{
    [SerializeField] private UICharacterCard[] cards = null;
    public StockSystem stockSystem { get; set; } = null;
    public ProbabilitySystem probabilitySystem { get; set; } = null;
    [SerializeField] private Button cheatPurchaseCharacter = null;

    void Start()
    {
        stockSystem = InGameManager.instance.stockSystem;
        probabilitySystem = InGameManager.instance.probabilitySystem;

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
                stockSystem.AddStockId(cardId);
            }

            Tier randomTier = probabilitySystem.GetRandomTier();
            int randomId = stockSystem.GetRandomId(randomTier);

            var characterDataSheet = DataBase.Instance.characterDataSheet;
            if (characterDataSheet == null)
            {
                Debug.LogError("Error characterDataSheet is null");
                return;
            }

            if (characterDataSheet.TryGetCharacterData(randomId, out var characterData))
            {
                card.SetCard(characterData);
                card.UpdateBuyable();
                card.OnShow();
                card.isBoughtCard = false;
            }
        }
    }

    public void CheatPurchaseCharacter(int id)
    {
        CharacterInfo characterInfo = new CharacterInfo(id);

        if (InGameManager.instance.combinationSystem.IsUpgradable(characterInfo))
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
        InGameManager.instance.combinationSystem.AddCharacter(new CharacterInfo(id));

        var characterDataSheet = DataBase.Instance.characterDataSheet;
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        int price = 0;
        if (characterDataSheet.TryGetCharacterTier(id, out var tier))
        {
            price = CardService.GetPriceByTier(tier);
        }

        InGameManager.instance.playerState.UseCoin(price);
    }
}
