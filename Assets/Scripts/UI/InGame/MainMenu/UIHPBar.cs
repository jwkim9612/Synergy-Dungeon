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
    private Coroutine afterImageCoroutine;

    public void Initialize()
    {
        InGameManager.instance.gameState.OnBattle += UpdateHPBar;

        var uiEnemy = GetComponentInParent<UIEnemy>();
        if(uiEnemy != null)
        {
            controllingPawn = uiEnemy.enemy;
            controllingPawn.OnHit += UpdateHPBarAndAfterImage;
            return;
        }

        var uiCharacter = GetComponentInParent<UICharacter>();
        if(uiCharacter != null)
        {
            controllingPawn = uiCharacter.character;
            controllingPawn.OnHit += UpdateHPBarAndAfterImage;
            return;
        }

        Debug.Log("Error UIHPBar Initialize");
    }

    public void UpdateHPBarAndAfterImage()
    {
        UpdateHPBar();
        afterImageCoroutine = StartCoroutine(PlayAfterImage());
    }

    public void UpdateHPBar()
    {
        slider.value = controllingPawn.GetHPRatio();
    }

    //public void PlayAfterImageCoroutine()
    //{
    //    Debug.Log("PlayAfterImageCoroutine");
    //}

    private IEnumerator PlayAfterImage()
    {

        float subValue = (afterImageSlider.value - controllingPawn.GetHPRatio()) / InGameService.Rate_At_Which_Afterimages_Disappear ;

        while(true)
        {
            yield return new WaitForEndOfFrame();

            if (afterImageSlider.value <= controllingPawn.GetHPRatio())
            {
                StopCoroutine(afterImageCoroutine);
            }

            afterImageSlider.value -= subValue;
        }
    }

    public void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }
}
