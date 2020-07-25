using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance = null;

    public CharacterStockSystem characterStockSystem;
    public ProbabilitySystem probabilitySystem;
    public CombinationSystem combinationSystem;
    public SynergySystem synergySystem;

    public InGamePlayerState playerState;
    public GameState gameState;

    public DraggableCentral draggableCentral;
    public BackCanvas backCanvas;
    public FrontCanvas frontCanvas;

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

        playerState.Initialize();
        gameState.Initialize();
        InitializeSystems();
        frontCanvas.Initialize();
        InGameService.Initialize();
    }

    private void InitializeSystems()
    {
        characterStockSystem = new CharacterStockSystem();
        probabilitySystem = new ProbabilitySystem();
        combinationSystem = new CombinationSystem();
        synergySystem = new SynergySystem();

        characterStockSystem.Initialize();
        probabilitySystem.Initialize();
        combinationSystem.Initialize();
        synergySystem.Initialize();
    }
}
