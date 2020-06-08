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
                    long remainingTime = (long)(response.ScriptData.GetLong("RemainingTime"));

                    SetHeart(heart);
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

    private void SetHeart(long heart)
    {
        if(heart == 0)
        {
            image.color = Color.black;
            heartText.text = "";
        }
        else if(heart == 1)
        {
            image.color = Color.red;
            heartText.text = "";
        }
        else
        {
            image.color = Color.red;
            heartText.text = "" + heart;
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
}
