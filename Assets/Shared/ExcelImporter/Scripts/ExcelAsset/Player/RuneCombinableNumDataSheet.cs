using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RuneCombinableNumDataSheet : ScriptableObject
{
	public List<RuneCombinableNumExcelData> RuneCombinableNumExcelDatas;
    private Dictionary<RuneGrade, int> RuneCombinableNumDatas;

    public void Initialize()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        RuneCombinableNumDatas = new Dictionary<RuneGrade, int>();

        foreach (var runeCombinableNumExcelData in RuneCombinableNumExcelDatas)
        {
            RuneGrade grade = runeCombinableNumExcelData.Grade;
            int num = runeCombinableNumExcelData.Num;

            RuneCombinableNumDatas.Add(grade, num);
        }
    }

    public bool TryGetRuneCombinableNum(RuneGrade grade, out int num)
    {
        num = 0;

        if (RuneCombinableNumDatas.TryGetValue(grade, out var runeCombinableNum))
        {
            num = runeCombinableNum;
            return true;
        }

        Debug.LogError($"Error TryGetRuneCombinableNum grade:{grade}");
        return false;
    }
}
