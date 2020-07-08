using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioEvent
{
    private int currentWave;
    private int currentChapter;
    private int currentStage;
    private int currentProbability;
    private InGameEvent_ScenarioDataSheet scenarioDataSheet;

    public void Initialize()
    {
        if (SaveManager.Instance.IsLoadedData)
        {
            currentStage = StageManager.Instance.currentStage;
        }

        scenarioDataSheet = DataBase.Instance.inGameEvent_ScenarioDataSheet;
        if (scenarioDataSheet == null)
        {
            Debug.LogError("Error scenarioDataSheet is null");
            return;
        }
    }

    public void UpdateStageData()
    {
        var stageManager = StageManager.Instance;

        if (currentStage != stageManager.currentStage)
        {
            currentProbability = 0;
        }

        Debug.Log(currentProbability + "= probability");

        currentWave = stageManager.currentWave;
        currentChapter = stageManager.currentChapter;
        currentStage = stageManager.currentStage;
    }

    public void IncreaseProbability(ScenarioData scenarioData)
    {
        currentProbability += scenarioData.ScenarioProbability;
    }

    public string GetTitleText()
    {
        if (scenarioDataSheet.TryGetScenarioDescripion(currentChapter, currentWave, InGameService.INDEX_OF_SCENARIO_TITLE, out var description))
        {
            return description;
        }

        Debug.LogError($"Error GetTitleText currentChapter:{currentChapter} currentWave:{currentWave} INDEX_OF_SCENARIO_TITLE:{InGameService.INDEX_OF_SCENARIO_TITLE}");
        return "";
    }

    public ScenarioData GetScenarioDataByScenarioId(int scenarioId)
    {
        if (scenarioDataSheet.TryGetScenarioData(currentChapter, currentWave, scenarioId, out var scenarioData))
        {
            return scenarioData;
        }

        Debug.LogError($"Error GetScenarioDataByScenarioId currentChapter:{currentChapter} currentWave:{currentWave} scenarioId:{scenarioId}");
        return null;
    }

    public string GetDescriptionByScenarioId(int scenarioId)
    {
        if(scenarioDataSheet.TryGetScenarioDescripion(currentChapter, currentWave, scenarioId, out var description))
        {
            return description;
        }

        Debug.LogError($"Error GetDescriptionByScenarioId currentChapter:{currentChapter} currentWave:{currentWave} scenarioId:{scenarioId}");
        return "";
    }

    public bool HasScenarioData()
    {
        if (IsCurrentWaveLessThanScenarioStartingWave())
            return false;

        if (!IsWaveHasScenarioEvent())
            return false;

        if (!IsProbabilitySufficient())
            return false;

        return true;
    }

    private bool IsCurrentWaveLessThanScenarioStartingWave()
    {
        if (currentWave < InGameService.NUMBER_OF_SCENARIO_STARTING_WAVE)
        {
            Debug.Log($"시나리오는 {InGameService.NUMBER_OF_SCENARIO_STARTING_WAVE}웨이브부터 나옵니다");
            return true;
        }

        return false;
    }

    private bool IsWaveHasScenarioEvent()
    {
        if (scenarioDataSheet.TryGetScenarioDescripion(currentChapter, currentWave, InGameService.INDEX_OF_SCENARIO_TITLE, out var description))
        {
            if (description == "")
            {
                Debug.Log("현재 웨이브에는 시나리오가 없습니다.");
                return false;
            }

            return true;
        }

        Debug.LogError("Error IsWaveHasScenarioEvent");
        return false;
    }

    private bool IsProbabilitySufficient()
    {
        if (scenarioDataSheet.TryGetScenarioProbability(currentChapter, currentWave, InGameService.INDEX_OF_SCENARIO_TITLE, out var probability))
        {
            if (probability > currentProbability)
            {
                Debug.Log("확률이 부족합니다.");
                return false;
            }

            return true;
        }

        Debug.LogError("Error IsProbabilitySufficient");
        return false;
    }
}
