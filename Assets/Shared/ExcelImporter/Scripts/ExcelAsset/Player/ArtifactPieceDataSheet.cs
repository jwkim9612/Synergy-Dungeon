using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ArtifactPieceDataSheet : ScriptableObject
{
	public List<ArtifactPieceExcelData> ArtifactPieceExcelDatas;
	private Dictionary<int, ArtifactPieceData> ArtifactPieceDatas;

    public void Initialize()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        ArtifactPieceDatas = new Dictionary<int, ArtifactPieceData>();

        foreach (var ArtifactPieceExcelData in ArtifactPieceExcelDatas)
        {
            ArtifactPieceData artifactPieceData = new ArtifactPieceData(ArtifactPieceExcelData);
            ArtifactPieceDatas.Add(artifactPieceData.Id, artifactPieceData);
        }
    }

    public bool TryGetArtifactPieceName(int artifactPieceId, out string name)
    {
        name = "";

        if (TryGetArtifactPieceData(artifactPieceId, out var artifactPieceData))
        {
            name = artifactPieceData.Name;
            return true;
        }

        Debug.LogWarning($"Error TryGetArtifactPieceName artifactPieceId:{artifactPieceId}");
        return false;
    }

    public bool TryGetArtifactPieceImage(int artifactPieceId, out Sprite sprite)
    {
        sprite = null;

        if (TryGetArtifactPieceData(artifactPieceId, out var artifactPieceData))
        {
            sprite = artifactPieceData.Image;
            return true;
        }

        Debug.LogWarning($"Error TryGetArtifactPieceImage artifactPieceId:{artifactPieceId}");
        return false;
    }


    public bool TryGetArtifactPieceData(int artifactPieceId, out ArtifactPieceData data)
    {
        data = null;

        if (ArtifactPieceDatas.TryGetValue(artifactPieceId, out var artifactPieceData))
        {
            data = new ArtifactPieceData(artifactPieceData);
            return true;
        }

        Debug.LogWarning($"Error TryGetArtifactPieceData artifactPieceId:{artifactPieceId}");
        return false;
    }
}
