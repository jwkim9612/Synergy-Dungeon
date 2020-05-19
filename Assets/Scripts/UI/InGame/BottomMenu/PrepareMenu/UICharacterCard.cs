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

    public CharacterData characterData { get; set; }
    public bool isBoughtCard { get; set; } = false;

    void Start()
    {
        InGameManager.instance.playerState.OnCoinChanged += UpdateBuyable;

        buyButton.onClick.AddListener(() =>
        {
            CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(characterData.Id);

            if (InGameManager.instance.combinationService.IsUpgradable(characterInfo))
            {
                BuyCharacter();
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
                    BuyCharacter();
                }
            }
        });
    }

    private void BuyCharacter()
    {
        CharacterInfo characterInfo = CharacterService.CreateCharacterInfo(characterData.Id);

        InGameManager.instance.combinationService.AddCharacter(characterInfo);
        InGameManager.instance.playerState.UseCoin(CardService.GetPriceByTier(characterData.Tier));
        isBoughtCard = true;
        OnHide();
    }

    public void SetCard(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetCharacterImage(characterData.Image);
        SetPriceText(CardService.GetPriceByTier(characterData.Tier).ToString());
        SetTribeImage(characterData.TribeData.Image);
        SetTribeText(characterData.TribeData.Name.ToString());
        SetOriginImage(characterData.OriginData.Image);
        SetOriginText(characterData.OriginData.Name.ToString());
        SetCharacterNameText(characterData.Name);
        SetTierBorderImage(CardService.GetColorByTier(characterData.Tier));
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
        int currentPlayerCoin = InGameManager.instance.playerState.coin;
        int cardPrice = CardService.GetPriceByTier(characterData.Tier);

        return currentPlayerCoin >= cardPrice;
    }
}
