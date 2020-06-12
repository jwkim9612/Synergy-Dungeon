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
    public SynergyService synergyService;
    public PlayerState playerState;
    public GameState gameState;
    public DraggableCentral draggableCentral;
    public UIBattleArea uiBattleArea;

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
        synergyService = new SynergyService();

        playerState.Initialize();
        stockService.Initialize();
        probabilityService.Initialize();
        combinationService.Initialize();
        synergyService.Initialize();
        InGameService.Initialize();
    }
}