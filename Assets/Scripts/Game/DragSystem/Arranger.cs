using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public List<UICharacter> uiCharacters;

    void Start()
    {
        uiCharacters = new List<UICharacter>();

        UpdateChildren();
    }

    public void UpdateChildren()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (i == uiCharacters.Count)
            {
                uiCharacters.Add(null);
            }

            // border안에 또 캐릭터가 있어서 GetChild를 두 번 써줌
            var uicharacter = gameObject.GetComponentsInChildren<UISlot>()[i].GetComponentInChildren<UICharacter>();
            //var child = transform.GetChild(i).GetChild(0);

            if(uicharacter != uiCharacters[i])
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
}
