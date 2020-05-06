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

        SetName(characterData.name);
        SetImage(characterData.image);

        SetCharacterAbility(characterData.oneStarAbility);
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
        SetCharacterAbility(characterData.oneStarAbility);
    }

    public void OnTwoStarClick()
    {
        SetCharacterAbility(characterData.twoStarAbility);
    }

    public void OnThreeStarClick()
    {
        SetCharacterAbility(characterData.threeStarAbility);
    }

    private void SetCharacterAbility(AbilityData abilityData)
    {
        textMaxHP.text = abilityData.maxHP.ToString();
        textMaxMP.text = abilityData.maxMP.ToString();
        textAttack.text = abilityData.attack.ToString();
        textDefense.text = abilityData.defense.ToString();
        textDexterity.text = abilityData.dexterity.ToString();
        textIntellect.text = abilityData.intellect.ToString();
    }
}
