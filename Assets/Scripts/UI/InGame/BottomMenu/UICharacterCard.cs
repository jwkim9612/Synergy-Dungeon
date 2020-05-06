using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterCard : MonoBehaviour
{
    [SerializeField] public Image characterImage = null;
    [SerializeField] private Text priceText = null;
    [SerializeField] private Image tribeImage = null;
    [SerializeField] private Text tribeText = null;
    [SerializeField] private Image originImage = null;
    [SerializeField] private Text originText = null;
    [SerializeField] private Text characterNameText = null;
    [SerializeField] private Image tierBorderImage = null;
    [SerializeField] private Button buyButton = null;

    public CharacterData characterData;
    public bool isBoughtCard = false;

    void Start()
    {
        InGameManager.instance.playerState.OnCoinChanged += UpdateBuyable;

        CombinationService combinationService = InGameManager.instance.combinationService;

        buyButton.onClick.AddListener(() =>
        {
            CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(characterData.id);

            if (combinationService.IsUpgradable(characterInfo))
            {
                BuyCharacter(combinationService);
            }
            else
            {
                var emptyUICharacter = InGameManager.instance.uiPrepareArea.GetEmptyUICharacter();
                if (emptyUICharacter == null)
                {
                    Debug.Log("uiCharacter is full");
                }
                else
                {
                    emptyUICharacter.SetCharacter(characterInfo);
                    BuyCharacter(combinationService);
                }
            }
        });
    }

    private void BuyCharacter(CombinationService combinationService)
    {
        CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(characterData.id);

        combinationService.AddCharacter(characterInfo);
        isBoughtCard = true;
        OnHide();
        InGameManager.instance.playerState.UseCoin(CardService.GetPriceByTier(characterData.tier));
    }

    public void SetCard(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetCharacterImage(characterData.image);
        SetPriceText(CardService.GetPriceByTier(characterData.tier).ToString());
        SetTribeImage(characterData.tribeData.Sheet[characterData.tribeData.idxList[0]].image);
        SetTribeText(characterData.tribeData.Sheet[characterData.tribeData.idxList[0]].strTribe);
        SetOriginImage(characterData.originData.Sheet[characterData.originData.idxList[0]].image);
        SetOriginText(characterData.originData.Sheet[characterData.originData.idxList[0]].strOrigin);
        SetCharacterNameText(characterData.name);
        SetTierBorderImage(CardService.GetColorByTier(characterData.tier));
    }

    public void SetCharacterImage(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }

    public void SetPriceText(string text)
    {
        priceText.text = text;
    }

    public void SetTribeImage(Sprite sprite)
    {
        tribeImage.sprite = sprite;
    }

    public void SetTribeText(string text)
    {
        tribeText.text = text;
    }

    public void SetOriginImage(Sprite sprite)
    {
        originImage.sprite = sprite;
    }

    public void SetOriginText(string text)
    {
        originText.text = text;
    }

    public void SetCharacterNameText(string text)
    {
        characterNameText.text = text;
    }


    public void SetTierBorderImage(Color color)
    {
        tierBorderImage.color = color;
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }

    public void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    public void UpdateBuyable()
    {
        if (IsBuyable())
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public bool IsBuyable()
    {
        int currentPlayerCoin = InGameManager.instance.playerState.Coin;
        int cardPrice = CardService.GetPriceByTier(characterData.tier);

        return currentPlayerCoin >= cardPrice;
    }
}
