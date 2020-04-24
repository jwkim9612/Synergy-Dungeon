using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    public CharacterInfo characterInfo;
    [SerializeField] private Image image;

    public void SetCharacterInfo(int characterIndex)
    {
        characterInfo = new CharacterInfo(characterIndex, CharacterService.NUM_OF_DEFAULT_STAR);
        image.sprite = GameManager.instance.dataSheet.characterDatas[characterIndex].image;
    }

    public void DeleteCharacterInfo()
    {
        characterInfo = null;
    }
}
