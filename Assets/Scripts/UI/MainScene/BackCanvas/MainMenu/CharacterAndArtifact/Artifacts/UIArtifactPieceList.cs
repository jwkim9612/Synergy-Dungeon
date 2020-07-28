using Boo.Lang;
using UnityEngine;
using UnityEngine.UI;

public class UIArtifactPieceList : MonoBehaviour
{
    [SerializeField] private UIArtifactPiece uiArtifactPiece = null;
    [SerializeField] private GridLayoutGroup gridLayout = null;
    private List<UIArtifactPiece> uiArtifactPieceList;

    public void Initialize()
    {
        InitializeArtifactPieceList();

        ArtifactManager.Instance.OnAddArtifactPiece += UpdateArtifactPiece;
    }

    private void InitializeArtifactPieceList()
    {
        uiArtifactPieceList = new List<UIArtifactPiece>();

        var artifactPieceDataSheet = DataBase.Instance.artifactPieceDataSheet;
        if (artifactPieceDataSheet.TryGetArtifactPieceDatas(out var artifactPieceDatas))
        {
            foreach (var artifactPiece in artifactPieceDatas)
            {
                var uiArtifactPiece = Instantiate(this.uiArtifactPiece, gridLayout.transform);

                bool isOwnedArtifact = false;
                var ownedArtifactPieceIdList = ArtifactManager.Instance.ownedPieceIdList;
                if (ownedArtifactPieceIdList.Contains(artifactPiece.Value.Id))
                {
                    isOwnedArtifact = true;
                }
                uiArtifactPiece.SetArtifactPiece(artifactPiece.Value.Id, isOwnedArtifact);
                uiArtifactPieceList.Add(uiArtifactPiece);
            }
        }

        uiArtifactPiece.OnHide();
    }

    public void UpdateArtifactPiece(int id)
    {
        var ownedArtifactPieceIdList = ArtifactManager.Instance.ownedPieceIdList;
        if (ownedArtifactPieceIdList.Contains(id))
        {
            uiArtifactPieceList.Find(x => x.id == id, out var uiArtifactPiece);
            if(uiArtifactPiece != null)
            {
                uiArtifactPiece.SetOn();
            }
        }
    }
}
