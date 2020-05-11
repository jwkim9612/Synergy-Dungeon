﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;

    public StockService stockService;
    public ProbabilityService probabilityService;
    public CombinationService combinationService;
    public BattleLogService battleLogService;
    public PlayerState playerState;
    public GameState gameState;
    public DraggableCentral draggableCentral;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Start()
    {
        stockService = new StockService();
        probabilityService = new ProbabilityService();
        combinationService = new CombinationService();

        stockService.Initialize();
        probabilityService.Initialize();
        combinationService.Initialize();
    }
}