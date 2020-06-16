using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;

    public StockSystem stockSystem;
    public ProbabilitySystem probabilitySystem;
    public CombinationSystem combinationSystem;
    public SynergySystem synergySystem;
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
        UIManager.Instance.SetCanEscape(true);

        stockSystem = new StockSystem();
        probabilitySystem = new ProbabilitySystem();
        combinationSystem = new CombinationSystem();
        synergySystem = new SynergySystem();

        playerState.Initialize();
        stockSystem.Initialize();
        probabilitySystem.Initialize();
        combinationSystem.Initialize();
        synergySystem.Initialize();
        InGameService.Initialize();
    }
}