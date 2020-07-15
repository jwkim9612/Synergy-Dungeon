using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void OnPrepareDelegate();
    public delegate void OnBattleDelegate();
    public delegate void OnCompleteDelegate();
    public OnPrepareDelegate OnPrepare { get; set; }
    public OnBattleDelegate OnBattle { get; set; }
    public OnCompleteDelegate OnComplete { get; set; }

    public InGameState inGameState { get; set; } = InGameState.None;
    public StageManager stageManager { get; set; }

    public bool isWaveClear { get; set; } = false;
    public bool isPlayerLose { get; set; } = false;

    [SerializeField] private UIStageClear uiStageClear = null;
    [SerializeField] private UIGameOver uiGameOver = null;

    void Start()
    {
        stageManager = StageManager.Instance;

        SetInGameState(InGameState.Prepare);
    }
    
    void Update()
    {
        if (inGameState == InGameState.Battle && isWaveClear)
        {
            SetInGameState(InGameState.Complete);
        }
        else if(inGameState == InGameState.Battle && isPlayerLose)
        {
            Debug.Log("패배");
            SetInGameState(InGameState.Lose);
        }
    }

    public void SetInGameState(InGameState newInGameState)
    {
        inGameState = newInGameState;

        switch (inGameState)
        {
            case InGameState.Prepare:
                OnPrepare();
                break;

            case InGameState.Battle:
                isWaveClear = false;
                OnBattle();
                break;

            case InGameState.Complete:
                if(stageManager.IsFinalWave())
                {
                    PlayerDataManager.Instance.playerData.IncreasePlayableStage();
                    PlayerDataManager.Instance.playerData.InitializeTopWave();
                    PlayerDataManager.Instance.SavePlayerData();
                    ShowStageClear();
                }
                else
                {
                    stageManager.IncreaseWaveAndSetCurrentStage(1);
                    SetInGameState(InGameState.Prepare);
                }
                OnComplete();
                break;

            case InGameState.Lose:
                PlayerDataManager.Instance.playerData.TopWave = StageManager.Instance.currentWave - 1;
                // 보상 주기.
                PlayerDataManager.Instance.SavePlayerData();
                ShowGameOver();
                break;
        }

    }

    /// <summary>
    /// 웨이브 클리어함으로 바꿔주는 함수
    /// </summary>
    public void SetIsWaveClear()
    {
        isWaveClear = true;
    }

    public void SetIsPlayerLose()
    {
        isPlayerLose = true;
    }

    public bool IsInBattle()
    {
        return inGameState == InGameState.Battle;
    }

    private void ShowGameOver()
    {
        uiGameOver.gameObject.SetActive(true);
    }

    private void ShowStageClear()
    {
        uiStageClear.gameObject.SetActive(true);
    }
}
