using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public delegate void OnPrepareDelegate();
    public delegate void OnBattleDelegate();
    public OnPrepareDelegate OnPrepare;
    public OnBattleDelegate OnBattle;

    public InGameState inGameState = InGameState.None;

    //public Timer timer;
    public StageManager stageManager;

    //[SerializeField] private UIBattleMenu uiBattleMenu;

    public bool isWaveClear = false;
    public bool isPlayerLose = false;

    void Start()
    {
        stageManager = GameManager.instance.stageManager;

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
                //OnHideBattleMenu();
                break;

            case InGameState.Battle:
                isWaveClear = false;
                OnBattle();
                //OnShowBattleMenu(); 
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

    /// <summary>
    /// 웨이브 클리어함으로 바꿔주는 함수
    /// </summary>
    public void SetIsWaveClear()
    {
        isWaveClear = true;
    }

    //public void OnShowBattleMenu()
    //{
    //    uiBattleMenu.gameObject.SetActive(true);
    //}

    //public void OnHideBattleMenu()
    //{
    //    uiBattleMenu.gameObject.SetActive(false);
    //}
}
