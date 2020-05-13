using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public List<UICharacter> uiCharacters { get; set; }

    protected void Start()
    {
        uiCharacters = new List<UICharacter>();

        UpdateChildren();
    }

    public virtual void UpdateChildren()
    {
        //for (int i = 0; i < transform.childCount; ++i)
        //{
        //    if (i == uiCharacters.Count)
        //    {
        //        uiCharacters.Add(null);
        //    }

        //    // border안에 또 캐릭터가 있어서 GetChild를 두 번 써줌
        //    var uicharacter = gameObject.GetComponentsInChildren<UISlot>()[i].GetComponentInChildren<UICharacter>();
        //    //var child = transform.GetChild(i).GetChild(0);

        //    if(uicharacter != uiCharacters[i])
        //    {
        //        uiCharacters[i] = uicharacter;
        //        //uiCharacters[i].character.SetSize(1.0f);
        //    }
        //}
    }

    public UICharacter GetCharacterByPosition(UICharacter character)
    {
        UICharacter targetCharacter = null;

        for(int i = 0; i < uiCharacters.Count; ++i)
        { 
            if(TransformService.ContainPos(uiCharacters[i].transform as RectTransform, character.transform.position))
            {
                targetCharacter = uiCharacters[i];
                break;
            }
        }

        return targetCharacter;
    }

    public List<CharacterInfo> GetAllCharacterInfo()
    {
        List<CharacterInfo> characterInfoList = new List<CharacterInfo>();

        foreach (var uiCharacter in uiCharacters)
        {
            characterInfoList.Add(uiCharacter.characterInfo);
        }

        return characterInfoList;
    }

    public void InitializeByInGameSaveData(List<CharacterInfo> characterInfoList)
    {
        for (int i = 0; i < uiCharacters.Count; ++i)
        {
            if (characterInfoList[i].star == 0)
            {
                continue;
            }

            InGameManager.instance.stockService.RemoveStockId(characterInfoList[i]);
            InGameManager.instance.combinationService.AddCharacter(characterInfoList[i]);
            uiCharacters[i].SetCharacter(characterInfoList[i]);
        }
    }
}
