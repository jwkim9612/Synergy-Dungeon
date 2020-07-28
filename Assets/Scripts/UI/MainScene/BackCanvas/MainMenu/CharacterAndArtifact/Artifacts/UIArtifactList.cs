using UnityEngine;
using UnityEngine.UI;

public class UIArtifactList : MonoBehaviour
{
    [SerializeField] private UIArtifact uiArtifact = null;
    [SerializeField] private GridLayoutGroup gridLayout = null;

    public void Initialize()
    {
        InitializeArtifactsList();
    }

    private void InitializeArtifactsList()
    {
        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;
        if (artifactPieceDataSheet.TryGetArtifactPieceDatas(out var artifactPieceDatas))
        {
            foreach (var artifactPiece in artifactPieceDatas)
            {
                var uiArtifact = Instantiate(this.uiArtifact, gridLayout.transform);

                bool isOwnedArtifact = false;
                var ownedArtifactPieceIdList = ArtifactManager.Instance.ownedPieceIdList;
                if (ownedArtifactPieceIdList.Contains(artifactPiece.Value.Id))
                {
                    isOwnedArtifact = true;
                }
                uiArtifact.SetArtifact(artifactPiece.Value.Id, isOwnedArtifact);
            }
        }

        uiArtifact.OnHide();
    }
}
