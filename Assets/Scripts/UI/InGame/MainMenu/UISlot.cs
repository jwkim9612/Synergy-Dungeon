using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    public UICharacter uiCharacter { get; set; }

    public bool HasCharacter()
    {
        uiCharacter = gameObject.GetComponentInChildren<UICharacter>();

        if (uiCharacter.characterInfo.id != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public void SetUICharacter(int characterIndex)
    //{
    //    uiCharacter.OnCanClick();
    //    uiCharacter.SetCharacterInfo(characterIndex);
    //}
}
