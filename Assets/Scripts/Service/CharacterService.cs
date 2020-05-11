using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class CharacterService
{
    public const int NUM_OF_DEFAULT_STAR = 1;
    public const int NUMBER_REQUIRED_FOR_COMBINATION = 3;

    public static CharacterInfo CreateCharacterInfo(int id)
    {
        CharacterInfo characterInfo;
        characterInfo.id = id;
        characterInfo.star = NUM_OF_DEFAULT_STAR;

        return characterInfo;
    }

    public static CharacterInfo CreateCharacterInfo(int id, int numOfStar)
    {
        CharacterInfo characterInfo;
        characterInfo.id = id;
        characterInfo.star = numOfStar;

        return characterInfo;
    }

    public static int GetSalePrice(CharacterInfo characterInfo)
    {
        int price = 0;

        switch (characterInfo.star)
        {
            case 1:
                price = (int)(GameManager.instance.dataSheet.characterDatas[characterInfo.id].tier);
                break;
            case 2:
                price = (int)(GameManager.instance.dataSheet.characterDatas[characterInfo.id].tier) + 2;
                break;
            case 3:
                price = (int)(GameManager.instance.dataSheet.characterDatas[characterInfo.id].tier) + 4;
                break;
            default:
                Debug.Log("Error GetSalePrice");
                break;
        }

        return price;
    }
}