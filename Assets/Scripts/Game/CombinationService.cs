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
}
