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
    public bool isDone = false;

    private void Start()
    {
        TimerSetting();
        OnTimeOut += TimeOut;
    }

    public void TimerStart()
    {
        //IsDone = false;
        isStarted = true;
        OnTimerStart(); 
    }

    void Update()
    {
        if(isStarted)
        {
            timeLimit -= Time.deltaTime;
        }

        if(IsTimeOut())
        {
            OnTimeOut();
        }
    }

    public void TimeOut()
    {
        isDone = true;
        isStarted = false;
        TimerSetting();
    }

    public bool IsTimeOut()
    {
        // 타이머 text가 1에서 0이 되는 순간 없어지게 하기 위해
        return timeLimit < 1.0f || isDone;
    }

    void TimerSetting()
    {
        timeLimit = timeLimitSetting;
    }
}
