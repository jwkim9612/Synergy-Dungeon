using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationService
{
    Dictionary<CharacterInfo, int> ownedCharacter;

    public void Initialize()
    {
        ownedCharacter = new Dictionary<CharacterInfo, int>();
    }
   

    public void AddCharacter(CharacterInfo characterInfo)
    { 
        if (ownedCharacter.ContainsKey(characterInfo))
        {
            ++ownedCharacter[characterInfo];
        }
        else
        {
            ownedCharacter.Add(characterInfo, 1);
        }

        // 3개가 모였으면
        if(ownedCharacter[characterInfo] == CharacterService.NUMBER_REQUIRED_FOR_COMBINATION)
        {
            InGameManager.instance.draggableCentral.CombinationCharacter(characterInfo);
            ownedCharacter.Remove(characterInfo);
        }
    }

    public void SubCharacter(CharacterInfo characterInfo)
    {
        if (ownedCharacter.ContainsKey(characterInfo))
        {
            --ownedCharacter[characterInfo];
        }
        else
        {
            Debug.Log("Error No Character");
        }
    }

    public bool IsCanUpgrade(CharacterInfo characterInfo)
    {
        // 해당 키가 있고
        if(ownedCharacter.ContainsKey(characterInfo))
        {
            // 2개가 있으면
            if(ownedCharacter[characterInfo] == CharacterService.NUMBER_REQUIRED_FOR_COMBINATION - 1)
            {
                return true;
            }
        }

        return false;
    }
}
