using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public List<UICharacter> uiCharacters { get; set; }

    public void Initialize()
    {
        uiCharacters = new List<UICharacter>();

        UpdateChildren();

        foreach (var uiCharacter in uiCharacters)
        {
            uiCharacter.Initialize();
        }
    }

    public virtual void UpdateChildren()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (i == uiCharacters.Count)
            {
                uiCharacters.Add(null);
            }

            // border안에 또 캐릭터가 있어서 GetChild를 두 번 써줌
            var uicharacter = gameObject.GetComponentsInChildren<UISlot>()[i].GetComponentInChildren<UICharacter>();

            if (uicharacter != uiCharacters[i])
            {
                uiCharacters[i] = uicharacter;
            }
        }
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
            if (characterInfoList[i] == null)
            {
                continue;
            }

            InGameManager.instance.stockSystem.RemoveStockId(characterInfoList[i]);
            InGameManager.instance.combinationSystem.AddCharacter(characterInfoList[i]);
            uiCharacters[i].SetCharacter(characterInfoList[i]);
        }
    }

    public void SpaceExpansion()
    {
        RectTransform rect = transform as RectTransform;
        //rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + InGameService.SIZE_TO_EXPAND_THE_BATTLE_AREA);

    }

    public void SpaceReduction()
    {
        RectTransform rect = transform as RectTransform;
        //rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - InGameService.SIZE_TO_EXPAND_THE_BATTLE_AREA);
    }
}
