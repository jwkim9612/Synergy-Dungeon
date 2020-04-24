using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void OnTimeOutDelegate();
    public OnTimeOutDelegate OnTimeOut;

    public delegate void OnTimerStartDelegate();
    public OnTimerStartDelegate OnTimerStart;

    public float timeLimitSetting;
    public float timeLimit = 0.0f;
    public bool isStarted = false;

    private void Start()
    {
        //TimerStart();

        InGameManager.instance.gameState.OnPrepare += TimerStart;
    }

    public void TimerStart()
    {
        TimerSetting();
        isStarted = true;
        OnTimerStart(); 
    }

    void Update()
    {
        if(isStarted)
        {
            timeLimit -= Time.deltaTime;
        }

        if(isStarted && IsTimeOut())
        {
            TimeOut();
        }
    }

    public void TimeOut()
    {
        OnTimeOut();
        isStarted = false;
        timeLimit = 0.0f;
        InGameManager.instance.gameState.SetInGameState(InGameState.Battle);
    }

    public bool IsTimeOut()
    {
        // 타이머 text가 1에서 0이 되는 순간 없어지게 하기 위해
        return timeLimit < 1.0f;
    }

    void TimerSetting()
    {
        timeLimit = timeLimitSetting;
    }
}
