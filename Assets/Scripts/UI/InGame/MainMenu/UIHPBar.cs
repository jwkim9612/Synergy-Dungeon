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

    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += UpdateHPBar;
        //InGameManager.instance.gameState.OnBattle += InitializeAfterImageSlider;
    }

    public void Initialize()
    {
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

    private void InitializeAfterImageSlider()
    {
        afterImageSlider.value = 1;
    }

    public void UpdateHPBarAndAfterImage()
    {
        UpdateHPBar();
        afterImageCoroutine = StartCoroutine(PlayAfterImage());
    }

    public void UpdateHPBar()
    {
        Debug.Log(controllingPawn.name + " : Update Hp Bar");

        if(controllingPawn != null)
        {
            slider.value = controllingPawn.GetHPRatio();
        }
        else
        {
            Debug.Log("Error Update HP Bar. ControllingPawn is null");
        }
    }

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
