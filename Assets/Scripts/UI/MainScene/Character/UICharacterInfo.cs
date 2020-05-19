using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterInfo : UIControl
{ 
    [SerializeField] private Text textName = null;
    [SerializeField] private Image image = null;
    [SerializeField] private Text textMaxHP = null;
    [SerializeField] private Text textMaxMP = null;
    [SerializeField] private Text textAttack = null;
    [SerializeField] private Text textDefense = null;
    [SerializeField] private Text textDexterity = null;
    [SerializeField] private Text textIntellect = null;

    private CharacterData characterData;

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        SetName(characterData.Name);
        SetImage(characterData.Image);

        SetCharacterAbility(GameManager.instance.dataSheet.characterAbilityDataSheet.OneStarDatas[characterData.Id]);
    }

    public void SetName(string name)
    {
        if (name != null)
        {
            textName.text = name;
        }
        else
        {
            Debug.Log("No Character Name");
        }
    }

    public void SetImage(Sprite sprite)
    {
        if (sprite != null)
        {
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("No Character Image");
        }
    }

    public void OnOneStarClick()
    {
        SetCharacterAbility(GameManager.instance.dataSheet.characterAbilityDataSheet.OneStarDatas[characterData.Id]);
    }

    public void OnTwoStarClick()
    {
        SetCharacterAbility(GameManager.instance.dataSheet.characterAbilityDataSheet.TwoStarDatas[characterData.Id]);
    }

    public void OnThreeStarClick()
    {
        SetCharacterAbility(GameManager.instance.dataSheet.characterAbilityDataSheet.ThreeStarDatas[characterData.Id]);
    }

    private void SetCharacterAbility(CharacterAbilityData characterAbilityData)
    {
        textMaxHP.text = characterAbilityData.Health.ToString();
        textMaxMP.text = characterAbilityData.MagicDefence.ToString();
        textAttack.text = characterAbilityData.Attack.ToString();
        textDefense.text = characterAbilityData.Defence.ToString();
        textDexterity.text = characterAbilityData.AttackSpeed.ToString();
        textIntellect.text = characterAbilityData.MagicAttack.ToString();
    }
}
