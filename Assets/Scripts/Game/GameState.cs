using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void OnPrepareDelegate();
    public OnPrepareDelegate OnPrepare;

    public InGameState inGameState = InGameState.None;

    public Timer timer;
    public StageManager stageManager;

    [SerializeField] private UIBattleMenu uiBattleMenu;

    public bool isWaveClear = false;
    public bool isPlayerLose = false;

    void Start()
    {
        stageManager = GameManager.instance.stageManager;

        SetInGameState(InGameState.Prepare);
    }
    
    void Update()
    {
        if (inGameState == InGameState.Play && isWaveClear)
        {
            SetInGameState(InGameState.Complete);
        }
        else if(inGameState == InGameState.Play && isPlayerLose)
        {
            Debug.Log("패배");
        }
    }

    public void SetInGameState(InGameState newInGameState)
    {
        inGameState = newInGameState;

        switch (inGameState)
        {
            case InGameState.Prepare:
                OnPrepare();
                timer.TimerStart();
                OnHideBattleMenu();
                break;

            case InGameState.Play:
                isWaveClear = false;
                OnShowBattleMenu(); 
                break;

            case InGameState.Complete:
                if(stageManager.IsFinalWave())
                {
                    Debug.Log("스테이지 클리어");
                }
                else
                {
                    stageManager.IncreaseWave(1);
                    SetInGameState(InGameState.Prepare);
                }
                break;

            case InGameState.Lose:

                break;
        }

    }

    public void OnShowBattleMenu()
    {
        uiBattleMenu.gameObject.SetActive(true);
    }

    public void OnHideBattleMenu()
    {
        uiBattleMenu.gameObject.SetActive(false);
    }
}
