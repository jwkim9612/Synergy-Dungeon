using Boo.Lang;
using UnityEngine;

public class ArtifactCombinationData
{
    public ArtifactCombinationData(ArtifactCombinationExcelData artifactCombinationExcelData)
    {
        Id = artifactCombinationExcelData.Id;
        Name = artifactCombinationExcelData.Name;
        ArtifactPieceIds = artifactCombinationExcelData.ArtifactPieceIds;
        InitializeEnemyIds();

        AbilityData = new AbilityData();
        AbilityData.SetAbilityData(artifactCombinationExcelData);

        Image = Resources.Load<Sprite>(artifactCombinationExcelData.ImagePath);
    }

    private void InitializeEnemyIds()
    {
        ArtifactPieceIdList = new List<int>();

        string[] ArtifactPieceIdsStr = ArtifactPieceIds.Split(',');
        foreach (var ArtifactPieceId in ArtifactPieceIdsStr)
        {
            ArtifactPieceIdList.Add(ArtifactPieceId[0] - '0');
        }
    }

    public int Id;
    public string Name;
    public string ArtifactPieceIds;
    public List<int> ArtifactPieceIdList;
    public AbilityData AbilityData;
    public Sprite Image;
}
