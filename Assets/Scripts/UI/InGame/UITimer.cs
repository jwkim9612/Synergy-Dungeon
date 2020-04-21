using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text textTimer = null;
    public Timer timer;

    private void Start()
    {
        timer.OnTimeOut += OnHide;
        timer.OnTimerStart += OnShow;
    }

    void Update()
    {
        textTimer.text = "" + Mathf.Round(timer.timeLimit);
    }

    void OnHide()
    {
        gameObject.SetActive(false);
    }

    void OnShow()
    {
        gameObject.SetActive(true);
    }
}
