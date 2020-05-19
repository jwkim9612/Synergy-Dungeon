using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class StageManager : MonoSingleton<StageManager>
{
    public delegate void OnChangedWaveDelegate();
    public OnChangedWaveDelegate OnChangedWave { get; set; }
    
    public int currentChapter = 1;
    public int currentWave = 1;
    public ChapterData currentChapterData = null;

    public void Initialize()
    {

    }

    public void SetChapterData(int chapter)
    {
        currentChapter = chapter;
        currentChapterData = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[currentChapter - 1];
    }

    public float GetRelativePercentageByStage()
    {
        float totalWave = currentChapterData.TotalWave;

        return currentWave / totalWave;
    }

    public void IncreaseWave(int increaseValue)
    {
        currentWave = Mathf.Clamp(currentWave + increaseValue, 1, (currentChapterData.TotalWave));
        OnChangedWave();
    }

    public bool IsFinalWave()
    {
        return currentWave == currentChapterData.TotalWave;
    }

}
