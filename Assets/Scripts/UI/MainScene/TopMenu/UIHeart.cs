using GameSparks.Api.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Text heartText = null;
    [SerializeField] private Text timeText = null;
    private long remainingTime;
    private long currentHeart;

    public void Initialize()
    {
        HeartUpdate();
    }

    public void HeartUpdate()
    {
        new LogEventRequest()
            .SetEventKey("HeartUpdate")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    long heart = (long)(response.ScriptData.GetLong("Heart"));
                    long ExtraHearts = (long)(response.ScriptData.GetLong("ExtraHearts"));
                    long remainingTime = (long)(response.ScriptData.GetLong("RemainingTime"));

                    SetHeart(heart, ExtraHearts);
                    this.remainingTime = remainingTime;

                    if (heart < 5)
                        StartCoroutine(Co_HeartTimer());
                    else
                        timeText.text = "0:00";
                }
                else
                {
                    Debug.Log("Error Time Load !");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    private void SetHeart(long heart, long extraHearts)
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

    private IEnumerator Co_HeartTimer()
    {
        while (remainingTime > 0)
        {
            timeText.text = remainingTime / 60 + ":" + remainingTime % 60;
            yield return new WaitForSeconds(1.0f);
            --remainingTime;
        }

        HeartUpdate();
    }

    public bool HasHeart()
    {
        if(currentHeart > 0)
            return true;

        return false;
    }
}
