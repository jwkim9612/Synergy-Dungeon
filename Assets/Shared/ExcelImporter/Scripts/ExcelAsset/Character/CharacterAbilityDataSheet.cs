using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class CharacterAbilityDataSheet : ScriptableObject
{
	public List<CharacterAbilityData> OneStarDatas;
	public List<CharacterAbilityData> TwoStarDatas;
	public List<CharacterAbilityData> ThreeStarDatas;

	public CharacterAbilityData GetAbilityDataByStar(CharacterInfo characterInfo)
	{
		CharacterAbilityData abilityData = null;

		switch (characterInfo.star)
		{
			case 1:
				abilityData = OneStarDatas[characterInfo.id];
				break;
			case 2:
				abilityData = TwoStarDatas[characterInfo.id];
				break;
			case 3:
				abilityData = ThreeStarDatas[characterInfo.id];
				break;
			default:
				Debug.Log("Error GetAbilityDataByStar");
				break;
		}

		return abilityData;
	}
}
