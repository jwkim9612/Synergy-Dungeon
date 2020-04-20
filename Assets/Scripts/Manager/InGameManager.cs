using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;

    public StockService stockService = new StockService();
    public ProbabilityService probabilityService = new ProbabilityService();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Initialize();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 다른 씬으로 이동해도 소멸되지 않음
        // DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        stockService.Initialize();
        probabilityService.Initialize();
    }
}