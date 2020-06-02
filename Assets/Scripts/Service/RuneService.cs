using Shared.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneService
{
    public static Dictionary<RuneGrade, List<int>> ListOfRuneIdsByGrade;

    public static void Initialize()
    {
        InitializeListOfRuneIdsByGrade();
    }

    private static void InitializeListOfRuneIdsByGrade()
    {
        // 각 등급별로 초기화
        ListOfRuneIdsByGrade = new Dictionary<RuneGrade, List<int>>();
        foreach (RuneGrade runeGrade in Enum.GetValues(typeof(RuneGrade)))
        {
            if (runeGrade == RuneGrade.None)
                continue;

            ListOfRuneIdsByGrade.Add(runeGrade, new List<int>());
        }

        // 룬 데이터를 돌면서 각 등급에 맞게 id값 넣어주기.
        var runeDatas = GameManager.instance.dataSheet.runeDataSheet.RuneDatas;
        foreach (var runeData in runeDatas)
        {
            ListOfRuneIdsByGrade[runeData.Value.Grade].Add(runeData.Key);
        }
    }

    public static int GetRandomIdByGrade(RuneGrade runeGrade)
    {
        var runeIdList = ListOfRuneIdsByGrade[runeGrade];
        int randomIndex = RandomService.RandRange(0, runeIdList.Count - 1);

        return runeIdList[randomIndex];      
    }

    public const int NUMBER_OF_RUNE_SOCKETS = 5;

    public const int INDEX_OF_ARCHER_SOCKET = 0;
    public const int INDEX_OF_PALADIN_SOCKET = 1;
    public const int INDEX_OF_THIEF_SOCKET = 2;
    public const int INDEX_OF_WARRIOR_SOCKET = 3;
    public const int INDEX_OF_WIZARD_SOCKET = 4;

}
