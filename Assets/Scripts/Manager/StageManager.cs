using UnityEngine;

public class StageManager : MonoSingleton<StageManager>
{
    public int currentChapter = 1;
    public int currentWave = 1;
    public ChapterData currentChapterData = null;

    public void Initialize()
    {
        currentWave = 1;
    }

    public void SetChapterData(int chapter)
    {
        currentChapter = chapter;
        DataBase.Instance.chapterDataSheet.TryGetChapterData(currentChapter, out currentChapterData);
    }

    public float GetRelativePercentageByStage()
    {
        float totalWave = currentChapterData.TotalWave;

        return currentWave / totalWave;
    }

    public void IncreaseWave(int increaseValue)
    {
        currentWave = Mathf.Clamp(currentWave + increaseValue, 1, (currentChapterData.TotalWave));
    }

    public bool IsFinalWave()
    {
        return currentWave == currentChapterData.TotalWave;
    }

}
