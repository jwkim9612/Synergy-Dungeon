using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PotionExcelData
{
    public int Id;
    public string Name;
    public PotionGrade Grade;
    public Ability Ability;
    public WayOfCalculate WayOfIncrease;
    public int IncreasePercentage;
    public int IncreaseValue;
    public string Description;
    public string ImagePath;
}
