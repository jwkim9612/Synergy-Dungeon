using UnityEngine;
using UnityEngine.UI;

public class UIReward : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Text text = null;
    [SerializeField] private Button button = null;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            OnHide();
            transform.parent.gameObject.SetActive(false);
        });
    }
    
    public void SetReward(ScenarioData scenarioData)
    {
        text.text = scenarioData.RewardDescription;
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
