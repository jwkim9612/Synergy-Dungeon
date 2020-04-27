using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    public CharacterInfo characterInfo;
    [SerializeField] private Image image = null;

    public void SetCharacterInfo(int characterIndex)
    {
        OnCanClick();

        //characterInfo = new CharacterInfo(characterIndex, CharacterService.NUM_OF_DEFAULT_STAR);
        characterInfo.id = characterIndex;
        characterInfo.star = CharacterService.NUM_OF_DEFAULT_STAR;

        image.sprite = GameManager.instance.dataSheet.characterDatas[characterIndex].image;

        InGameManager.instance.combinationService.AddCharacter(characterInfo);
    }

    public void DeleteCharacterBySell()
    {
        InGameManager.instance.stockService.AddStockId(characterInfo);
        DeleteCharacter();
    }

    public void DeleteCharacter()
    {
        image.sprite = Resources.Load<Sprite>(CardService.DEFAULT_IMAGE_NAME);

        //characterInfo = null;
        characterInfo.id = -1;
        characterInfo.star = 0;

        OnCanNotClick();
    }

    public void UpgradeStar()
    {
        ++characterInfo.star;
        InGameManager.instance.combinationService.AddCharacter(characterInfo);
    }

    public void OnCanClick()
    {
        image.raycastTarget = true;
    }

    public void OnCanNotClick()
    {
        image.raycastTarget = false;
    }
}
