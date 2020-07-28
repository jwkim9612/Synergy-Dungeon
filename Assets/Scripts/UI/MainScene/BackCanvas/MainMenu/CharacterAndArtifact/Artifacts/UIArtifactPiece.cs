using UnityEngine;
using UnityEngine.UI;

public class UIArtifactPiece : MonoBehaviour
{
    [SerializeField] private Button showInfoButton;
    [SerializeField] private Image artifactImage;
    public int id;

    public void SetArtifactPiece(int id, bool isOwned)
    {
        this.id = id;

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

    public void SetOn()
    {
        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;
        if (artifactPieceDataSheet.TryGetArtifactPieceOnImage(id, out var image))
        {
            artifactImage.sprite = image;
        }
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
