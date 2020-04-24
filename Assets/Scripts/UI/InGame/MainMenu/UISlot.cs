using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    UICharacter uiCharacter;

    public bool HasCharacter()
    {
        uiCharacter = gameObject.GetComponentInChildren<UICharacter>();

        if(uiCharacter.characterInfo != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetUICharacter(int characterIndex)
    {
        uiCharacter.SetCharacterInfo(characterIndex);
    }
}
