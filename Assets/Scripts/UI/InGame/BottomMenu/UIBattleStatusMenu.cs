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
    [SerializeField] private Text canNotStartText = null;
    private Coroutine CanNotStartCoroutine;

    void Start()
    {
        UpdateCoinText();
        UpdateReloadable();
        InGameManager.instance.playerState.OnCoinChanged += UpdateReloadable;
        InGameManager.instance.gameState.OnBattle += DisableMenus;
        InGameManager.instance.gameState.OnPrepare += ActivateMenus;

        reloadButton.onClick.AddListener(() => {
            InGameManager.instance.playerState.UseCoin(CardService.RELOAD_PRICE);
            characterPurchase.Shuffle();
        });

        startButton.onClick.AddListener(() => {
            if(InGameManager.instance.draggableCentral.uiCharacterArea.IsEmpty())
            {
                ShowCanNotStart();
            }
            else
            {
                HideCanNotStart();
                InGameManager.instance.gameState.SetInGameState(InGameState.Battle);
            }
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
        if (InGameManager.instance.gameState.IsInBattle())
            return false;

        int currentPlayerCoin = InGameManager.instance.playerState.coin;
        int reloadPrice = CardService.RELOAD_PRICE;

        return currentPlayerCoin >= reloadPrice;
    }

    public void UpdateCoinText()
    {
        coinText.text = InGameManager.instance.playerState.coin.ToString();
    }

    private void ActivateMenus()
    {
        startButton.interactable = true;
        UpdateReloadable();
    }

    private void DisableMenus()
    {
        startButton.interactable = false;
        reloadButton.interactable = false;
    }

    private void ShowCanNotStart()
    {
        if (canNotStartText.gameObject.activeSelf)
        {
            StopCoroutine(CanNotStartCoroutine);
        }

        CanNotStartCoroutine = StartCoroutine(CanNotStart());
    }

    private void HideCanNotStart()
    {
        if (canNotStartText.gameObject.activeSelf)
        {
            StopCoroutine(CanNotStartCoroutine);
            canNotStartText.gameObject.SetActive(false);
        }
    }

    private IEnumerator CanNotStart()
    {
        canNotStartText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        canNotStartText.gameObject.SetActive(false);
        yield break;
    }
}
