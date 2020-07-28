using UnityEngine;
using UnityEngine.UI;

public class UIArtifact : MonoBehaviour
{
    [SerializeField] private Button showInfoButton;
    [SerializeField] private Image artifactImage;

    public void SetArtifact(int id, bool isOwned)
    {
        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;

        if(isOwned)
        {
            if (artifactPieceDataSheet.TryGetArtifactPieceOnImage(id, out var image))
            {
                artifactImage.sprite = image;
            }
        }
        else
        {
            if (artifactPieceDataSheet.TryGetArtifactPieceOffImage(id, out var image))
            {
                artifactImage.sprite = image;
            }
        }
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
