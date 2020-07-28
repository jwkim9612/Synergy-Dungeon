using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ArtifactCombinationDataSheet : ScriptableObject
{
	public List<ArtifactCombinationExcelData> ArtifactCombinationExcelDatas;
    private Dictionary<int, ArtifactCombinationData> ArtifactCombinationDatas;

    public void Initialize()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        ArtifactCombinationDatas = new Dictionary<int, ArtifactCombinationData>();

        foreach (var ArtifactCombinationExcelData in ArtifactCombinationExcelDatas)
        {
            ArtifactCombinationData artifactCombinationData = new ArtifactCombinationData(ArtifactCombinationExcelData);
            ArtifactCombinationDatas.Add(artifactCombinationData.Id, artifactCombinationData);
        }
    }

    public bool TryGetArtifactCombinationDatas(out Dictionary<int, ArtifactCombinationData> artifactCombinationDatas)
    {
        artifactCombinationDatas = new Dictionary<int, ArtifactCombinationData>(ArtifactCombinationDatas);
        if (artifactCombinationDatas != null)
        {
            return true;
        }

        Debug.LogError("Error TryGetArtifactCombinationDatas");
        return false;
    }
}
