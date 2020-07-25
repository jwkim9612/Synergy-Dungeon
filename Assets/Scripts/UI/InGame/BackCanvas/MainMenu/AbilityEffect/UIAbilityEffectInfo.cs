using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityEffectInfo : MonoBehaviour
{
    [SerializeField] private Text remainingTurnText;
    [SerializeField] private Text InfoText;

    public void Initialize()
    {
        InGameManager.instance.gameState.OnBattle += MoveForBattle;
        InGameManager.instance.gameState.OnPrepare += MoveForPrepare;
    }

    private void MoveForBattle()
    {
        RectTransform rect = transform as RectTransform;
        rect.Translate(new Vector3(0.0f, AbilityEffectService.Y_INCREASE_VALUE_FOR_BATTLE, 0.0f));
    }

    private void MoveForPrepare()
    {
        RectTransform rect = transform as RectTransform;
        rect.Translate(new Vector3(0.0f, AbilityEffectService.Y_INCREASE_VALUE_FOR_PREPARE, 0.0f));
    }

    public void SetAbilityEffectInfo(AbilityEffect abilityEffect)
    {
        SetRemainingTurnText(abilityEffect.remainingTurn);
        SetInfoText(abilityEffect.description);
    }

    private void SetRemainingTurnText(int remainingTurn)
    {
        if (remainingTurn == -1)
        {
            remainingTurnText.text = "지속 턴 : ∞";
        }
        else
        {
            remainingTurnText.text = $"지속 턴 : {remainingTurn}";
        }
    }

    private void SetInfoText(string text)
    {
        InfoText.text = text;
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
