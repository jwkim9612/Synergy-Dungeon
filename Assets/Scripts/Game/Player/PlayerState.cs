using UnityEngine;

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
            SatisfyExp = DataBase.Instance.inGameExpDataSheet.InGameExpDatas[level - 1].SatisfyExp;
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
        var chapterInfoDataSheet = DataBase.Instance.chapterInfoDataSheet;
        if (chapterInfoDataSheet == null)
        {
            Debug.LogError("Error chapterInfoDataSheet is null");
            return;
        }

        int currentChapter = StageManager.Instance.currentChapter;
        int currentWave = StageManager.Instance.currentWave;

        if(chapterInfoDataSheet.TryGetChapterInfoGoldAmount(currentChapter, currentWave, out var goldAmount))
        {
            IncreaseCoin(goldAmount);
        }
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
            SatisfyExp = DataBase.Instance.inGameExpDataSheet.InGameExpDatas[level - 1].SatisfyExp;
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
        var chapterInfoDateSheet = DataBase.Instance.chapterInfoDataSheet;
        if(chapterInfoDateSheet == null)
        {
            Debug.LogError("Error chapterInfoDataSheet is null");
            return;
        }

        int currentChapter = StageManager.Instance.currentChapter;
        int currentWave = StageManager.Instance.currentWave;

        if(chapterInfoDateSheet.TryGetChapterInfoExpAmount(currentChapter, currentWave, out var expAmount))
        {
            IncreaseExp(expAmount);
        }
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
