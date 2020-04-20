using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class InGameManager : MonoBehaviour
{
    public StockService stockService = new StockService();
    public ProbabilityService probabilityService = new ProbabilityService();

    public ProbabilitySheet probabilityDatas;

    public void Initialize()
    {
        stockService.Initialize();
        probabilityService.Initialize();
    }
}