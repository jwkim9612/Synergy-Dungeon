using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Slider afterImageSlider = null;
    private Pawn controllingPawn = null;

    Coroutine coroutine;

    public void Initialize()
    {
        var uiPawn = GetComponentInParent<UIEnemy>();
        if(uiPawn != null)
        {
            controllingPawn = uiPawn.enemy;
            controllingPawn.OnHit += UpdateHpBar;
            return;
        }
        else
        {
            Debug.Log("Error UIHPBar Initialize");
        }
    }

    public void UpdateHpBar()
    {
        slider.value = controllingPawn.GetHPRatio();
        coroutine = StartCoroutine(PlayAfterImage());
    }

    private IEnumerator PlayAfterImage()
    {
        float subValue = (afterImageSlider.value - controllingPawn.GetHPRatio()) / InGameService.Rate_At_Which_Afterimages_Disappear ;

        while(true)
        {
            yield return new WaitForEndOfFrame();

            if (afterImageSlider.value <= controllingPawn.GetHPRatio())
            {
                StopCoroutine(coroutine);
            }

            afterImageSlider.value -= subValue;
        }
    }
}
