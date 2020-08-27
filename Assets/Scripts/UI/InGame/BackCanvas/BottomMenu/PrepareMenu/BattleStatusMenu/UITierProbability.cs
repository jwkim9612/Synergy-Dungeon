using UnityEngine;
using UnityEngine.UI;

public class UITierProbability : MonoBehaviour
{
    [SerializeField] private Text oneTierProbability = null;
    [SerializeField] private Text twoTierProbability = null;
    [SerializeField] private Text threeTierProbability = null;
    [SerializeField] private Text fourTierProbability = null;

    public void Initialize()
    {
        UpdateTierProbability();

        InGameManager.instance.playerState.OnLevelUp += UpdateTierProbability;
    }

    public void UpdateTierProbability()
    {
        int currentLevel = InGameManager.instance.playerState.level;

        var probabilityDataSheet = DataBase.Instance.probabilityDataSheet;
        if(probabilityDataSheet.TryGetProbabilityData(currentLevel, out var probabilityData))
        {
            oneTierProbability.text = $"● {probabilityData.OneTier}%";
            twoTierProbability.text = $"● {probabilityData.TwoTier}%";
            threeTierProbability.text = $"● {probabilityData.ThreeTier}%";
            fourTierProbability.text = $"● {probabilityData.FourTier}%";
        }
    }

    private void OnDestroy()
    {
        if(InGameManager.instance != null)
        {
            InGameManager.instance.playerState.OnLevelUp -= UpdateTierProbability;
        }
    }
}
