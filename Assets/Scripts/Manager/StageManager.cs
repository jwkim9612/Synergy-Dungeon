using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class StageManager : MonoSingleton<StageManager>
{
    public delegate void OnChangedWaveDelegate();
    public OnChangedWaveDelegate OnChangedWave { get; set; }
    
    public int currentStage = 1;
    public int currentWave = 1;
    public StageData currentStageData = null;

    public void Initialize()
    {

    }

    public void SetStageData(int stage)
    {
        currentStage = stage;
        currentStageData = GameManager.instance.dataSheet.stageDatas[currentStage - 1];
    }

    public float GetRelativePercentageByStage()
    {
        float totalWave = currentStageData.totalWave;

        return currentWave / totalWave;
    }

    public void IncreaseWave(int increaseValue)
    {
        currentWave = Mathf.Clamp(currentWave + increaseValue, 1, currentStageData.totalWave);
        OnChangedWave();
    }

    public bool IsFinalWave()
    {
        return currentWave == currentStageData.totalWave;
    }

}
