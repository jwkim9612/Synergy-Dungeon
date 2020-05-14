using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusHPBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    private Character controllingPawn = null;

    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += UpdateHPBar;
    }

    public void SetControllingPawn(Character character)
    {
        if (character != null)
        {
            controllingPawn = character;
            controllingPawn.OnHit += UpdateHPBar;
        }
    }

    public void UpdateHPBar()
    {
        if (controllingPawn != null)
        {
            slider.value = controllingPawn.GetHPRatio();
        }
        else
        {
            Debug.Log("Error Update HP Bar. ControllingPawn is null");
        }
    }
}
