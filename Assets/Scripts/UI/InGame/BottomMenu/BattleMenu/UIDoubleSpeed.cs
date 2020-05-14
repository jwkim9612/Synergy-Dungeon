using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDoubleSpeed : MonoBehaviour
{
    [SerializeField] private Text speedText;
    private float currentSpeed;
    private float defaultSpeed;

    private void Start()
    {
        defaultSpeed = 1.0f;
        currentSpeed = defaultSpeed;
        ChangeText();

        InGameManager.instance.gameState.OnPrepare += ChangeToDefaultSpeed;
    }

    public void ChangeSpeed()
    {
        if(currentSpeed == 1.0f)
        {
            currentSpeed = 2.0f;
        }
        else
        {
            currentSpeed = 1.0f;
        }

        ChangeText();
        ChangeTimeScale();
    }

    public void ChangeText()
    {
        if (currentSpeed == 1.0f)
        {
            speedText.text = "X1";
        }
        else
        {
            speedText.text = "X2";
        }
    }
    
    public void ChangeToDefaultSpeed()
    {
        currentSpeed = defaultSpeed;
        ChangeText();
        ChangeTimeScale();
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = currentSpeed;
    }
}
