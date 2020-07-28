using UnityEngine;
using UnityEngine.UI;

public class UIArtifactInfo : UIControl
{
    [SerializeField] private Image artifactImage = null;
    [SerializeField] private Text artifactName = null;

    public void SetArtifactInfo(int artifactId, bool isOwned)
    {
        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;

        //if (artifactPieceDataSheet.TryGetArtifactPieceImage(artifactId, out var image))
        //{
        //    artifactImage.sprite = image;
        //}

        if (artifactPieceDataSheet.TryGetArtifactPieceName(artifactId, out var name))
        {
            artifactName.text = name;
        }
    }
}
