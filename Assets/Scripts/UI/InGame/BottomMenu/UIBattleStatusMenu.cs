using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleStatusMenu : MonoBehaviour
{
    [SerializeField] private Text coinText = null;
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button reloadButton = null;
   
    [SerializeField] private UICharacterPurchase characterPurchase = null;

    public Timer timer;

    void Start()
    {
        UpdateCoinText();
        UpdateReloadable();
        InGameManager.instance.playerState.OnCoinChanged += UpdateReloadable;

        reloadButton.onClick.AddListener(() => {
            InGameManager.instance.playerState.UseCoin(CardService.RELOAD_PRICE);
            characterPurchase.Shuffle();
        });

        startButton.onClick.AddListener(() => {
            timer.TimeOut();
        });
    }

    public void UpdateReloadable()
    {
        if (IsReloadable())
        {
            reloadButton.interactable = true;
        }
        else
        {
            reloadButton.interactable = false;
        }
    }

    public bool IsReloadable()
    {
        int currentPlayerCoin = InGameManager.instance.playerState.Coin;
        int reloadPrice = CardService.RELOAD_PRICE;

        return currentPlayerCoin >= reloadPrice;
    }

    public void UpdateCoinText()
    {
        coinText.text = InGameManager.instance.playerState.Coin.ToString();
    }
}
