using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChapterData
{
    public int Id;
    public string Name;
    public int TotalWave;
    public string ImagePath;

    public List<ChapterInfoData> chapterInfoDataList;
    public Sprite Image;
}
