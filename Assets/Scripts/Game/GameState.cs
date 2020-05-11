using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void OnPrepareDelegate();
    public delegate void OnBattleDelegate();
    public OnPrepareDelegate OnPrepare { get; set; }
    public OnBattleDelegate OnBattle { get; set; }

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
                InGameManager.instance.playerState.IncreaseCoin(3);
                OnPrepare();
                break;

            case InGameState.Battle:
                isWaveClear = false;
                OnBattle();
                break;

            case InGameState.Complete:
                if(stageManager.IsFinalWave())
                {
                    ShowStageClear();
                }
                else
                {
                    stageManager.IncreaseWave(1);
                    SetInGameState(InGameState.Prepare);
                }
                break;

            case InGameState.Lose:
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
