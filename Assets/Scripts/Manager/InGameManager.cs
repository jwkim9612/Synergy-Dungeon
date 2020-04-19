using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public StockService stockService = new StockService();


    public void Initialize()
    {
        stockService.InitializeStock();
    }
}
