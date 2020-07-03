using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScenarioEvent : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private List<UIScenarioEventButton> selectButtonList;

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

        InGameManager.instance.gameState.OnPrepare += CheckScenarioDataAndSetScenarioEvent;
    }

    private void CheckScenarioDataAndSetScenarioEvent()
    {
        UpdateStageData();

        if (IsCurrentWaveLessThanScenarioStartingWave())
            return;

        if (!IsWaveHasScenarioEvent())
            return;

        if (!IsProbabilitySufficient())
            return;

        SetTitleText();
        SetSelectButtonList();
        OnShow();
    }

    public void SetSelectButtonList()
    {
        for (int i = 1; i <= selectButtonList.Count; i++)
        {
            if (scenarioDataSheet.TryGetScenarioDescripion(currentChapter, currentWave, i, out var description))
            {
                selectButtonList[i].SetText(description);
                selectButtonList[i].SetButton(OnHide);
                selectButtonList[i].OnShow();
            }
            else
            {
                selectButtonList[i].OnHide();
            }
        }
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }

    private void SetTitleText()
    {
        if (scenarioDataSheet.TryGetScenarioDescripion(currentChapter, currentWave, InGameService.INDEX_OF_SCENARIO_TITLE, out var description))
        {
            titleText.text = description;
            return;
        }

        Debug.LogError($"Error SetTitleText currentChapter:{currentChapter} currentWave:{currentWave} INDEX_OF_SCENARIO_TITLE:{InGameService.INDEX_OF_SCENARIO_TITLE}");
    }

    private void UpdateStageData()
    {
        var stageManager = StageManager.Instance;

        if (currentStage != stageManager.currentStage)
        {
            currentProbability = 0;
        }

        currentWave = stageManager.currentWave;
        currentChapter = stageManager.currentChapter;
        currentStage = stageManager.currentStage;
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
