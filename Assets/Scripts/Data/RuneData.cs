using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneData
{
    public RuneData(RuneExcelData runeExcelData)
    {
        Id = runeExcelData.Id;
        Name = runeExcelData.Name;
        SocketPosition = runeExcelData.SocketPosition;
        Tier = runeExcelData.Tier;
        Prob = runeExcelData.Prob;
        Description = runeExcelData.Description;

        Ability.SetAbility(runeExcelData);

        Image = Resources.Load<Sprite>(runeExcelData.ImagePath);
    }

    public int Id;
    public string Name;
    public int SocketPosition;
    public int Tier;
    public int Prob;
    public string Description;
    public Ability Ability;
    public Sprite Image;
}
