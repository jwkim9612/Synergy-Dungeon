using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleStatusMenu : MonoBehaviour
{
    [SerializeField] private UIPlacementStatus uiPlacementStatus = null;
    [SerializeField] private UIWave uiWave = null;
    [SerializeField] private Text coinText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Text expText = null;
    [SerializeField] private Button addExpButton = null;
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button reloadButton = null;
    [SerializeField] private UICharacterPurchase characterPurchase = null;
    [SerializeField] private Text canNotStartText = null;
    private Coroutine CanNotStartCoroutine;

    void Start()
    {
        UpdateAddExpable();
        UpdateCoinText();
        UpdateReloadable();
        UpdateExpText();
        UpdateLevelText();
        uiPlacementStatus.UpdatePlacementStatus();
        InGameManager.instance.playerState.OnCoinChanged += UpdateAddExpable;
        InGameManager.instance.playerState.OnCoinChanged += UpdateReloadable;
        InGameManager.instance.playerState.OnExpChanged += UpdateExpText;
        InGameManager.instance.playerState.OnLevelUp += UpdateLevelText;
        InGameManager.instance.playerState.OnLevelUp += UpdateAddExpable;
        InGameManager.instance.gameState.OnBattle += DisableMenus;
        InGameManager.instance.gameState.OnPrepare += ActivateMenus;

        addExpButton.onClick.AddListener(() => {
            InGameManager.instance.playerState.IncreaseExpByAddExp();
        });
   
        reloadButton.onClick.AddListener(() => {
            InGameManager.instance.playerState.UseCoin(CardService.RELOAD_PRICE);
            characterPurchase.Shuffle();
        });

        startButton.onClick.AddListener(() => {
            if (InGameManager.instance.draggableCentral.uiCharacterArea.IsEmpty())
            {
                ShowCanNotStart();
            }
            else
            {
                HideCanNotStart();
                InGameManager.instance.gameState.SetInGameState(InGameState.Battle);
            }
        });

        InGameManager.instance.gameState.OnPrepare += uiWave.UpdateText;
        InGameManager.instance.draggableCentral.uiCharacterArea.OnPlacementChanged += uiPlacementStatus.UpdatePlacementStatus;
        InGameManager.instance.playerState.OnLevelUp += uiPlacementStatus.UpdatePlacementStatus;
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

    public void UpdateAddExpable()
    {
        if (IsAddExpable())
        {
            addExpButton.interactable = true;
        }
        else
        {
            addExpButton.interactable = false;
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

    public bool IsAddExpable()
    {
        if (InGameManager.instance.gameState.IsInBattle())
            return false;

        if (InGameManager.instance.playerState.IsMaxLevel())
            return false;

        int currentPlayerCoin = InGameManager.instance.playerState.coin;
        int addExpPrice = CardService.ADDEXP_PRICE;

        return currentPlayerCoin >= addExpPrice;
    }

    public void UpdateCoinText()
    {
        coinText.text = InGameManager.instance.playerState.coin + "";
    }

    public void UpdateLevelText()
    {
        levelText.text = "Lv" + InGameManager.instance.playerState.level;
    }

    public void UpdateExpText()
    {
        if (InGameManager.instance.playerState.IsMaxLevel())
            expText.text = "Max";
        else
            expText.text = InGameManager.instance.playerState.exp + "/" + InGameManager.instance.playerState.SatisfyExp;
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
