using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public delegate void OnCoinChangedDelegate();
    public OnCoinChangedDelegate OnCoinChanged { get; set; }

    [SerializeField] private UIBattleStatusMenu uiBattleStatusMenu = null;
    
    public int coin { get; set; }

    private void Start()
    {
        if (SaveManager.Instance.HasInGameData())
        {
            coin = SaveManager.Instance.inGameSaveData.coin;
        }
        else
        {
            coin = 100;
        }

        OnCoinChanged += uiBattleStatusMenu.UpdateCoinText;
    }

    public void IncreaseCoin(int increaseValue)
    {
        coin += increaseValue;
        OnCoinChanged();
    }

    public void UseCoin(int usedValue)
    {
        coin = Mathf.Clamp(coin - usedValue, 0, coin);
        OnCoinChanged();
    }
}
