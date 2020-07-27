using UnityEngine;
using UnityEngine.UI;

public class UIArtifactStatus : MonoBehaviour
{
    [SerializeField] private Text artifactsNumText = null;
    [SerializeField] private Text unlockedArtifactsNumText = null;

    public void Initialize()
    {
        SetArtifactsNumText();
    }

    private void SetArtifactsNumText()
    {
        artifactsNumText.text = $"총 아티팩트 조각 갯수 : {ArtifactService.NUMBER_OF_ALL_ARTIFACTS}";
    }
}
