using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDoubleSpeed : MonoBehaviour
{
    [SerializeField] private Text speedText = null;
    private float currentSpeed;

    private void Start()
    {
        ChangeToDefaultSpeed();

        InGameManager.instance.gameState.OnPrepare += ChangeToDefaultSpeed;
    }

    public void ChangeSpeed()
    {
        if(currentSpeed == InGameService.DEFAULT_SPEED)
        {
            currentSpeed = InGameService.DOUBLE_SPEED;
        }
        else
        {
            currentSpeed = InGameService.DEFAULT_SPEED;
        }

        ChangeText();
        ChangeTimeScale();
    }

    public void ChangeText()
    {
        if (currentSpeed == InGameService.DEFAULT_SPEED)
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
        currentSpeed = InGameService.DEFAULT_SPEED;
        ChangeText();
        ChangeTimeScale();
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = currentSpeed;
    }
}
