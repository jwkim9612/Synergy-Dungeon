using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScenarioEventButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text descriptionText;
    [SerializeField] private UIReward uiReward = null;
    private ScenarioData scenarioData;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {

            SetRewardAndShowReward();
        });
    }

    public void SetButton(ScenarioData data)
    {
        SetScenarioData(data);
        SetText(data.Description);
    }

    public void SetText(string text)
    {
        this.descriptionText.text = text;
    }

    public void SetScenarioData(ScenarioData data)
    {
        scenarioData = data;
    }

    public void OnInvisible()
    {
        GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void OnVisible()
    {
        GetComponent<RectTransform>().localScale = Vector3.one;
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }

    public void SetRewardAndShowReward()
    {
        uiReward.SetReward(scenarioData);
        uiReward.OnShow();
    }

    private void Test()
    {
        switch (scenarioData.CurrencyType)
        {
            case RewardCurrency.None:
                break;
            case RewardCurrency.Gold:
                break;
            case RewardCurrency.Rune:
                break;
            case RewardCurrency.RandomRune:
                break;
            case RewardCurrency.RandomPotion:
                break;
            case RewardCurrency.Relic:
                break;
            case RewardCurrency.Artifact:
                break;
            case RewardCurrency.Coin:
                InGameManager.instance.playerState.IncreaseCoin(scenarioData.Amount);
                break;
            case RewardCurrency.Status:
                break;
            case RewardCurrency.RandomArtifactPiece:
                break;
            case RewardCurrency.Nothing:
                break;
            default:
                break;
        }
    }
}
