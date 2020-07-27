using UnityEngine;

public class ArtifactPieceData
{
    public ArtifactPieceData(ArtifactPieceExcelData artifactPieceExcelData)
    {
        Id = artifactPieceExcelData.Id;
        Name = artifactPieceExcelData.Name;
        DropProbability = artifactPieceExcelData.DropProbability;

        Image = Resources.Load<Sprite>(artifactPieceExcelData.ImagePath);
    }

    public ArtifactPieceData(ArtifactPieceData artifactPieceData)
    {
        Id = artifactPieceData.Id;
        Name = artifactPieceData.Name;
        DropProbability = artifactPieceData.DropProbability;
        Image = artifactPieceData.Image;
    }

    public int Id;
    public string Name;
    public int DropProbability;
    public Sprite Image;
}
