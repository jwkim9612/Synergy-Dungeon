using System.Collections.Generic;
using UnityEngine;

public class ArtifactPieceData
{
    public ArtifactPieceData(ArtifactPieceExcelData artifactPieceExcelData)
    {
        Id = artifactPieceExcelData.Id;
        Name = artifactPieceExcelData.Name;
        DropProbability = artifactPieceExcelData.DropProbability;

        OnImage = Resources.Load<Sprite>(artifactPieceExcelData.OnImagePath);
        OffImage = Resources.Load<Sprite>(artifactPieceExcelData.OffImagePath);

        InitializeCombinableArtifactsList();
    }

    public ArtifactPieceData(ArtifactPieceData artifactPieceData)
    {
        Id = artifactPieceData.Id;
        Name = artifactPieceData.Name;
        DropProbability = artifactPieceData.DropProbability;
        OnImage = artifactPieceData.OnImage;
        OffImage = artifactPieceData.OffImage;
        CombinableArtifactsList = artifactPieceData.CombinableArtifactsList;
    }

    private void InitializeCombinableArtifactsList()
    {
        CombinableArtifactsList = new List<int>();

        var artifactCombinationDataSheet = DataBase.Instance.artifactCombinationDataSheet;
        if (artifactCombinationDataSheet.TryGetArtifactCombinationDatas(out var artifactCombinationDatas))
        {
            foreach (var artifactCombinationData in artifactCombinationDatas)
            {
                if(artifactCombinationData.Value.ArtifactPieceIdList.Contains(this.Id))
                {
                    CombinableArtifactsList.Add(artifactCombinationData.Value.Id);
                }
            }
        }
    }

    public int Id;
    public string Name;
    public int DropProbability;
    public Sprite OffImage;
    public Sprite OnImage;
    public List<int> CombinableArtifactsList;
}
