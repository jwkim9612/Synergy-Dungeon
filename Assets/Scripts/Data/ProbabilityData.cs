using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityData
{
    public ProbabilityData(ProbabilityExcelData probabilityExcelData)
    {
        Level = probabilityExcelData.Level;
        OneTier = probabilityExcelData.OneTier;
        TwoTier = probabilityExcelData.TwoTier;
        ThreeTier = probabilityExcelData.ThreeTier;
        FourTier = probabilityExcelData.FourTier;
    }

    public int Level;
    public int OneTier;
    public int TwoTier;
    public int ThreeTier;
    public int FourTier;
}
