using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class CharacterDataSheet : ScriptableObject
{
	public List<CharacterExcelData> characterExcelDatas;
	public Dictionary<int, CharacterData> characterDatas;

	public void Initialize()
	{
		InitializeCharacterDatas();
	}

	private void InitializeCharacterDatas()
	{
        characterDatas = new Dictionary<int, CharacterData>();

        foreach (var characterExcelData in characterExcelDatas)
        {
			CharacterData characterData = new CharacterData(characterExcelData);
            characterDatas.Add(characterData.Id, characterData);
        }
    }
}
