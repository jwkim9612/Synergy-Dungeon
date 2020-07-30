﻿using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
    [SerializeField] private Text heartText = null;

    //[SerializeField] private Text timeText = null;

    //private long remainingTime;
    private long currentHeart;
    //private bool heartTimerIsRunning;

    public void Initialize()
    {

    }


    //public void HeartUpdate()
    //{
    //    new LogEventRequest()
    //        .SetEventKey("HeartUpdate")
    //        .Send((response) =>
    //        {
    //            if (!response.HasErrors)
    //            {
    //                long heart = (long)(response.ScriptData.GetLong("Heart"));
    //                long ExtraHearts = (long)(response.ScriptData.GetLong("ExtraHearts"));
    //                long remainingTime = (long)(response.ScriptData.GetLong("RemainingTime"));

    //                SetHeart(heart, ExtraHearts);
    //                this.remainingTime = remainingTime;

    //                if (heart < 5)
    //                {
    //                    if(!heartTimerIsRunning)
    //                        StartCoroutine(Co_HeartTimer());
    //                }
    //                else
    //                    timeText.text = "0:00";
    //            }
    //            else
    //            {
    //                Debug.Log("Error Time Load !");
    //                Debug.Log(response.Errors.JSON);
    //            }
    //        });
    //}

    public void SetHeart(long heart, long extraHearts)
    {
        currentHeart = heart + extraHearts;

        if(extraHearts > 0)
        {
            heartText.text = $"{heart}+{extraHearts}";
        }
        else
        {
            heartText.text = $"{heart}";
        }
    }

    //private IEnumerator Co_HeartTimer()
    //{
    //    heartTimerIsRunning = true;

    //    while (remainingTime > 0)
    //    {
    //        var minute = remainingTime / 60;
    //        var second = remainingTime % 60;

    //        timeText.text = $"{minute}:{second.ToString("D2")}";
    //        yield return new WaitForSeconds(1.0f);
    //        --remainingTime;
    //    }

    //    heartTimerIsRunning = false;
    //    HeartUpdate();
    //}

    /// <summary>
    /// 하트가 있는지 확인
    /// </summary>
    /// <returns></returns>
    public bool HasHeart()
    {
        if(currentHeart > 0)
            return true;

        return false;
    }
}
