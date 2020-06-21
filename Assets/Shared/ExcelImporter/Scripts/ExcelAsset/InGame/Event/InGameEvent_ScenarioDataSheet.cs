using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExcelAsset]
public class InGameEvent_ScenarioDataSheet : ScriptableObject
{
    public List<ScenarioExcelData> ScenarioExcelDatas;

    private Dictionary<int, List<ScenarioData>> ScenarioDatas;
    private Dictionary<int, Dictionary<int, List<ScenarioData>>> AllScenarioDatas;
    //public IEnumerable<ScenarioExcelData> scenarioExcelData => ScenarioExcelDatas;

    public void Initialize()
    {
        InitializeScenarioDatas();
    }

    private void InitializeScenarioDatas()
    {
        AllScenarioDatas = new Dictionary<int, Dictionary<int, List<ScenarioData>>>();

        InitializeChapterOneScenarioDatas();
    }

    private void InitializeChapterOneScenarioDatas()
    {
        int NumOfChapter = 1;
        ScenarioDatas = new Dictionary<int, List<ScenarioData>>();

        foreach (var ScenarioExcelData in ScenarioExcelDatas)
        {
            if (ScenarioDatas.ContainsKey(ScenarioExcelData.WaveId))
            {
                ScenarioData scenarioData = new ScenarioData(ScenarioExcelData);
                ScenarioDatas[ScenarioExcelData.WaveId].Add(scenarioData);
            }
            else
            {
                List<ScenarioData> scenarioDataList = new List<ScenarioData>();
                ScenarioData scenarioData = new ScenarioData(ScenarioExcelData);
                scenarioDataList.Add(scenarioData);
                ScenarioDatas.Add(ScenarioExcelData.WaveId, scenarioDataList);
            }
        }

        AllScenarioDatas.Add(NumOfChapter, ScenarioDatas);
    }
    
    public bool TryGetScenarioDatas(int chapterId, out Dictionary<int, List<ScenarioData>> scenarioDatas)
    {
        if (AllScenarioDatas.TryGetValue(chapterId, out scenarioDatas))
        {
            return true;
        }

        Debug.LogError($"Error TryGetScenarioDatas chapterId:{chapterId}");
        return false;
    }


    public bool TryGetScenarioDataList(int chapterId, int waveId, out List<ScenarioData> scenarioDataList)
    {
        scenarioDataList = null;

        if (TryGetScenarioDatas(chapterId, out var scenarioDatas))
        {
            if (scenarioDatas.TryGetValue(waveId, out scenarioDataList))
            {
                return true;
            }
        }

        Debug.LogError($"Error TryGetScenarioDataList chapterId:{chapterId} waveId:{waveId}");
        return false;
    }

    public bool TryGetScenarioData(int chapterId, int waveId, int scenarioId, out ScenarioData data)
    {
        data = null;

        if (TryGetScenarioDataList(chapterId, waveId, out var scenarioDataList))
        {
            foreach (var scenarioData in scenarioDataList)
            {
                if (scenarioData.ScenarioId == scenarioId)
                {
                    data = scenarioData;
                    return true;
                }
            }
        }

        Debug.LogError($"Error TryGetScenarioData chapterId:{chapterId} waveId:{waveId} scenarioId:{scenarioId}");
        return false;
    }

    public bool TryGetScenarioDescripion(int chapterId, int waveId, int scenarioId, out string description)
    {
        description = "";

        if (TryGetScenarioData(chapterId, waveId, scenarioId, out var data))
        {
            description = data.Description;
            return true;
        }

        Debug.LogError($"Error TryGetScenarioDescripion chapterId:{chapterId} waveId:{waveId} scenarioId:{scenarioId}");
        return false;
    }
}
