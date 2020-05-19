using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChapterInfoData
{
    public int ChapterId;
    public int WaveId;
    public int StageId;
    public int GoldAmount;
    public int ExpAmount;
    public string EnemyIds;
    public string FrontIds;
    public string BackIds;

    public List<int> EnemyIdList;
    public List<int> FrontIdList;
    public List<int> BackIdList;
}
