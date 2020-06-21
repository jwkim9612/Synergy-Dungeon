﻿using System.Collections.Generic;

public class ChapterInfoData
{
    public ChapterInfoData(ChapterInfoExcelData chapterInfoExcelData)
    {
        ChapterId = chapterInfoExcelData.ChapterId;
        WaveId = chapterInfoExcelData.WaveId;
        StageId = chapterInfoExcelData.StageId;
        GoldAmount = chapterInfoExcelData.GoldAmount;
        ExpAmount = chapterInfoExcelData.ExpAmount;
        EnemyIds = chapterInfoExcelData.EnemyIds;
        FrontIds = chapterInfoExcelData.FrontIds;
        BackIds = chapterInfoExcelData.BackIds;

        InitializeEnemyIds();
        InitializeFrontIds();
        InitializeBackIds();
    }

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

    private void InitializeEnemyIds()
    {
        EnemyIdList = new List<int>();

        string[] enemyIdsStr = EnemyIds.Split(',');
        foreach (var enemyId in enemyIdsStr)
        {
            EnemyIdList.Add(enemyId[0] - '0');
        }
    }

    private void InitializeFrontIds()
    {
        if (FrontIds == "")
            return;

        FrontIdList = new List<int>();

        string[] frontIdsStr = FrontIds.Split(',');
        foreach (var frontId in frontIdsStr)
        {
            FrontIdList.Add(frontId[0] - '0');
        }
    }

    private void InitializeBackIds()
    {
        if (BackIds == "")
            return;

        BackIdList = new List<int>();

        string[] backIdsStr = BackIds.Split(',');
        foreach (var backId in backIdsStr)
        {
            BackIdList.Add(backId[0] - '0');
        }
    }
}