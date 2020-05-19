using geniikw.DataSheetLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSheet : MonoBehaviour
{
    public CharacterDataSheet characterDataSheet;
	public TribeDataSheet tribeDataSheet;
	public OriginDataSheet originDataSheet;
	public ChapterDataSheet chapterDataSheet;
	public ChapterInfoDataSheet chapterInfoDataSheet;
	public CharacterAbilityDataSheet characterAbilityDataSheet;
	public EnemyDataSheet enemyDataSheet;
	public ProbabilityDataSheet probabilityDataSheet;

    public void Initialize()
    {
		characterDataSheet.Initialize();
		tribeDataSheet.Initialize();
		originDataSheet.Initialize();
		chapterDataSheet.Initialize();
		chapterInfoDataSheet.Initialize();
		enemyDataSheet.Initialize();

		//InitializeCharacterData();
	}

	//private void InitializeCharacterData()
	//{
	//	foreach (var characterData in characterData.characterData3)
	//	{
	//		characterData.sprite = Resources.Load<Sprite>(characterData.ImagePath);
	//	}
	//}
}
