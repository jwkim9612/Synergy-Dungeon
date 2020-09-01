using UnityEngine;
using UnityEngine.UI;

public class UIEventReward : MonoBehaviour
{
    [SerializeField] private UIReward uiReward = null;
    [SerializeField] private Text rewardDescriptionText = null;
    [SerializeField] private Button button = null;

    public void Initialize()
    {
        SetHideSenarioEventButton();
    }

    private void SetHideSenarioEventButton()
    {
        button.onClick.AddListener(() =>
        {
            OnHide();
            transform.parent.gameObject.SetActive(false);
        });
    }

    public void SetReward(ScenarioData scenarioData)
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
                uiReward.SetImage(InGameService.COIN_IMAGE);
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

        uiReward.SetAmountText(scenarioData.Amount.ToString());
        rewardDescriptionText.text = scenarioData.RewardDescription;
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
