using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionData
{
    public PotionData(PotionExcelData potionExcelData)
    {
        Id = potionExcelData.Id;
        Name = potionExcelData.Name;
        Grade = potionExcelData.Grade;
        Ability = potionExcelData.Ability;
        WayOfIncrease = potionExcelData.WayOfIncrease;
        IncreasePercentage = potionExcelData.IncreasePercentage;
        IncreaseValue = potionExcelData.IncreaseValue;

        Image = Resources.Load<Sprite>(potionExcelData.ImagePath);
    }

    public PotionData(PotionData potionData)
    {
        Id = potionData.Id;
        Name = potionData.Name;
        Grade = potionData.Grade;
        Ability = potionData.Ability;
        WayOfIncrease = potionData.WayOfIncrease;
        IncreasePercentage = potionData.IncreasePercentage;
        IncreaseValue = potionData.IncreaseValue;
        Image = potionData.Image;
    }

    public int Id;
    public string Name;
    public PotionGrade Grade;
    public Ability Ability;
    public WayOfCalculate WayOfIncrease;
    public int IncreasePercentage;
    public int IncreaseValue;
    public Sprite Image;
}
