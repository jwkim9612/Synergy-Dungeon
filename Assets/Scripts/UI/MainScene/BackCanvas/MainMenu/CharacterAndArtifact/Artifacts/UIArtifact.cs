using UnityEngine;
using UnityEngine.UI;

public class UIArtifact : MonoBehaviour
{
    [SerializeField] private Button showInfoButton;
    [SerializeField] private Image artifactImage;

    public void SetArtifact(int id)
    {
        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;
        if (artifactPieceDataSheet.TryGetArtifactPieceImage(id, out var image))
        {
            artifactImage.sprite = image;
        }


    }


}
