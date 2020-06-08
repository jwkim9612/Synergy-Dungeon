using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePurchaseableLevelData
{
    public RunePurchaseableLevelData(RunePurchaseableLevelExcelData runePurchaseableLevelExcelData)
    {
        SalesIndex = runePurchaseableLevelExcelData.SalesIndex;
        PurchaseableLevel = runePurchaseableLevelExcelData.PurchaseableLevel;
    }

    public int SalesIndex;
    public int PurchaseableLevel;
}
