using System.Collections;
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
    public GameState gameState;
    public UIPrepareArea uiPrepareArea;
    public DraggableCentral draggableCentral;

    public Button ClearButton;

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
        stockService = new StockService();
        probabilityService = new ProbabilityService();
        combinationService = new CombinationService();

        stockService.Initialize();
        probabilityService.Initialize();
        combinationService.Initialize();

        ClearButton.onClick.AddListener(() => {
            Debug.Log("Clear");
            gameState.isWaveClear = true;
            //gameState.SetInGameState(InGameState.Complete);
        });
    }
}