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

    public bool TryGetArtifactPieceOnImage(int artifactPieceId, out Sprite sprite)
    {
        sprite = null;

        if (TryGetArtifactPieceData(artifactPieceId, out var artifactPieceData))
        {
            sprite = artifactPieceData.OnImage;
            return true;
        }

        Debug.LogWarning($"Error TryGetArtifactPieceOnImage artifactPieceId:{artifactPieceId}");
        return false;
    }

    public bool TryGetArtifactPieceOffImage(int artifactPieceId, out Sprite sprite)
    {
        sprite = null;

        if (TryGetArtifactPieceData(artifactPieceId, out var artifactPieceData))
        {
            sprite = artifactPieceData.OffImage;
            return true;
        }

        Debug.LogWarning($"Error TryGetArtifactPieceOffImage artifactPieceId:{artifactPieceId}");
        return false;
    }

    public bool TryGetCombinableArtifactsIdList(int artifactPieceId, out List<int> artifactsIdList)
    {
        artifactsIdList = null;

        if (TryGetArtifactPieceData(artifactPieceId, out var artifactPieceData))
        {
            artifactsIdList = artifactPieceData.CombinableArtifactsList;
            return true;
        }

        Debug.LogWarning($"Error TryGetCombinableArtifactsIdList artifactPieceId:{artifactPieceId}");
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

    public bool TryGetArtifactPieceDatas(out Dictionary<int, ArtifactPieceData> artifactPieceDatas)
    {
        artifactPieceDatas = new Dictionary<int, ArtifactPieceData>(ArtifactPieceDatas);
        if (artifactPieceDatas != null)
        {
            return true;
        }

        Debug.LogError("Error TryGetArtifactPieceDatas");
        return false;
    }

    public bool TryGetArtifactPieceTotalNumber(out int totalNumber)
    {
        totalNumber = 0;
        
        if (TryGetArtifactPieceDatas(out var artifactPieceDatas))
        {
            totalNumber = artifactPieceDatas.Count;
            return true;
        }

        return false;
    }
}
