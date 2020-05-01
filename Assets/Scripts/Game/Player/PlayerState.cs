using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public delegate void OnCoinChangedDelegate();
    public OnCoinChangedDelegate OnCoinChanged;

    [SerializeField] private UIBattleStatusMenu uiBattleStatusMenu = null;

    public int Coin { get; set; }

    private void Start()
    {
        Coin = 0;

        OnCoinChanged += uiBattleStatusMenu.UpdateCoinText;
    }

    public void IncreaseCoin(int increaseValue)
    {
        Coin += increaseValue;
        OnCoinChanged();
    }

    public void UseCoin(int usedValue)
    {
        Coin = Mathf.Clamp(Coin - usedValue, 0, Coin);
        OnCoinChanged();
    }
}
