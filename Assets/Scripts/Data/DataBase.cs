public class DataBase : MonoSingleton<DataBase>
{
    public CharacterDataSheet characterDataSheet;
	public TribeDataSheet tribeDataSheet;
	public OriginDataSheet originDataSheet;
	public ChapterInfoDataSheet chapterInfoDataSheet;
	public ChapterDataSheet chapterDataSheet;
	public CharacterAbilityDataSheet characterAbilityDataSheet;
	public EnemyDataSheet enemyDataSheet;
	public ProbabilityDataSheet probabilityDataSheet;
	public InGameExpDataSheet inGameExpDataSheet;
	public PlayerExpDataSheet playerExpDataSheet;
	public RuneDataSheet runeDataSheet;
	public PotionDataSheet potionDataSheet;
	public GoodsDataSheet goodsDataSheet;
	public RunePurchaseableLevelDataSheet runePurchaseableLevelDataSheet;
	public InGameEvent_ScenarioDataSheet inGameEvent_ScenarioDataSheet;
	public RuneCombinableNumDataSheet runeCombinableNumDataSheet;
	public ArtifactDataSheet artifactDataSheet;
	public ArtifactPieceDataSheet artifactPieceDataSheet;

	public void Initialize()
    {
		CheckValidate();

		tribeDataSheet.Initialize();
		originDataSheet.Initialize();
		characterDataSheet.Initialize();
		characterAbilityDataSheet.Initialize();
		chapterInfoDataSheet.Initialize();
		chapterDataSheet.Initialize();
		enemyDataSheet.Initialize();
		probabilityDataSheet.Initialize();
		runeDataSheet.Initialize();
		potionDataSheet.Initialize();
		goodsDataSheet.Initialize();
		runePurchaseableLevelDataSheet.Initialize();
		inGameEvent_ScenarioDataSheet.Initialize();
		runeCombinableNumDataSheet.Initialize();
		inGameExpDataSheet.Initialize();
		playerExpDataSheet.Initialize();
		artifactDataSheet.Initialize();
		artifactPieceDataSheet.Initialize();
	}

	public void CheckValidate()
	{
		tribeDataSheet.DataValidate();
		originDataSheet.DataValidate();
		characterDataSheet.DataValidate();
		characterAbilityDataSheet.DataValidate();
		chapterInfoDataSheet.DataValidate();
		chapterDataSheet.DataValidate();
		enemyDataSheet.DataValidate();
		probabilityDataSheet.DataValidate();
		runeDataSheet.DataValidate();
		potionDataSheet.DataValidate();
		goodsDataSheet.DataValidate();
		runePurchaseableLevelDataSheet.DataValidate();
		inGameEvent_ScenarioDataSheet.DataValidate();
		runeCombinableNumDataSheet.DataValidate();
		inGameExpDataSheet.DataValidate();
		playerExpDataSheet.DataValidate();
		artifactDataSheet.DataValidate();
		artifactPieceDataSheet.DataValidate();
	}
}
