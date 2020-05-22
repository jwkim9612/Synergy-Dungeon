using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public delegate void OnCoinChangedDelegate();
    public delegate void OnExpChangedDelegate();
    public delegate void OnLevelUpDelegate();
    public OnCoinChangedDelegate OnCoinChanged { get; set; }
    public OnExpChangedDelegate OnExpChanged { get; set; }
    public OnLevelUpDelegate OnLevelUp { get; set; }

    [SerializeField] private UIBattleStatusMenu uiBattleStatusMenu = null;
    
    public int coin { get; set; }
    public int level;
    public int exp;
    public int SatisfyExp;
    public int numOfCanBePlacedInBattleArea;

    public void Initialize()
    {
        if (SaveManager.Instance.IsLoadedData)
        {
            coin = SaveManager.Instance.inGameSaveData.Coin;
            level = SaveManager.Instance.inGameSaveData.Level;
            SatisfyExp = GameManager.instance.dataSheet.inGameExpDataSheet.InGameExpDatas[level - 1].SatisfyExp;
            exp = SaveManager.Instance.inGameSaveData.Exp;
            numOfCanBePlacedInBattleArea = level;
        }
        else
        {
            coin = 100;
            level = 1;
            SatisfyExp = 2;
            exp = 0;
            numOfCanBePlacedInBattleArea = 1;
        }

        OnCoinChanged += uiBattleStatusMenu.UpdateCoinText;
        InGameManager.instance.gameState.OnPrepare += IncreaseCoinByPrepare;
        InGameManager.instance.gameState.OnComplete += IncreaseExpByBattleWin;
    }

    public void IncreaseCoin(int increaseValue)
    {
        coin += increaseValue;
        OnCoinChanged();
    }

    public void IncreaseCoinByPrepare()
    {
        IncreaseCoin(GameManager.instance.dataSheet.chapterInfoDataSheet.ChapterInfoDatas[StageManager.Instance.currentWave - 1].GoldAmount);
    }

    public void UseCoin(int usedValue)
    {
        coin = Mathf.Clamp(coin - usedValue, 0, coin);
        OnCoinChanged();
    }

    public void IncreaseExp(int increaseValue)
    {
        if (IsMaxLevel())
            return;

        exp += increaseValue;

        if(exp >= SatisfyExp)
        {
            level += 1;
            exp -= SatisfyExp;
            SatisfyExp = GameManager.instance.dataSheet.inGameExpDataSheet.InGameExpDatas[level - 1].SatisfyExp;
            IncreaseNumOfCanBePlacedInBattleArea(1);
            OnLevelUp();
        }

        OnExpChanged();
    }

    public void IncreaseExpByAddExp()
    {
        UseCoin(InGameService.CAN_BUY_EXP);
        IncreaseExp(InGameService.CAN_BUY_EXP);
    }

    public void IncreaseExpByBattleWin()
    {
        IncreaseExp(GameManager.instance.dataSheet.chapterInfoDataSheet.ChapterInfoDatas[StageManager.Instance.currentWave - 1].ExpAmount);
    }

    public void IncreaseNumOfCanBePlacedInBattleArea(int increaseValue)
    {
        Mathf.Clamp(numOfCanBePlacedInBattleArea += increaseValue, InGameService.MIN_NUMBER_OF_CAN_PLACED, InGameService.MAX_NUMBER_OF_CAN_PLACED);
    }


    public bool IsMaxLevel()
    {
        return InGameManager.instance.playerState.SatisfyExp == -1 ? true : false;
    }
}
