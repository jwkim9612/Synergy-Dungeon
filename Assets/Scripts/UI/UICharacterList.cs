using geniikw.DataSheetLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterList : MonoBehaviour
{
    public CharacterSheet characterDatas;

    void Start()
    {
        foreach (var characterData in characterDatas)
        {
            Debug.Log($"Name : {characterData.name}\tTribe : {characterData.tribeStr}\tOrigin : {characterData.originStr}");
        }
    }
}