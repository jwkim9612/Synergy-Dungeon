using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterData
{
    public ChapterData(ChapterExcelData chapterExcelData)
    {
        Id = chapterExcelData.Id;
        Name = chapterExcelData.Name;
        TotalWave = chapterExcelData.TotalWave;

        Image = Resources.Load<Sprite>(chapterExcelData.ImagePath);

        chapterInfoDataList = GameManager.instance.dataSheet.chapterInfoDataSheet.ChapterInfoDatas;
    }

    public int Id;
    public string Name;
    public int TotalWave;
    public List<ChapterInfoData> chapterInfoDataList;
    public Sprite Image;
}
