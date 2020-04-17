using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeLimit = 0.0f;
    public Text textTimer = null;

    void Update()
    {
        timeLimit -= Time.deltaTime;
        textTimer.text = "" + Mathf.Round(timeLimit);
    }
}
