using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStatus : MonoBehaviour
{
    [SerializeField] private Image characterIcon = null;
    [SerializeField] private Text characterName = null;
    [SerializeField] private HorizontalLayoutGroup starGrade = null;
    [SerializeField] private UIStatusHPBar uiStatusHPbar = null;
    private Image[] stars = null;
    private Character ControllingPawn { get; set; }
    
    public void Initialize()
    {
        stars = starGrade.GetComponentsInChildren<Image>();
    }

    public void SetCharacterStatus(UICharacter uiCharacter)
    {
        if (uiCharacter == null)
        {
            Debug.Log("Error SetCharacterStatus");
            return;
        }

        ShowAll();

        var characterDataSheet = DataBase.Instance.characterDataSheet;
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterName(uiCharacter.characterInfo.id, out var name))
        {
            SetCharacterName(name);
        }

        SetCharacterIcon(uiCharacter.character.spriteRenderer.sprite);
        //SetCharacterIcon(DataBase.Instance.characterDatas[uiCharacter.characterInfo.id].statusImage);
        SetStarGrade(uiCharacter.characterInfo.star);
        ControllingPawn = uiCharacter.character;
        uiStatusHPbar.SetControllingPawn(ControllingPawn);
    }

    private void SetCharacterIcon(Sprite sprite)
    {
        if (sprite == null)
            return;

        characterIcon.sprite = sprite;
    }

    private void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    private void SetStarGrade(int star)
    {
        for (int i = 0; i < stars.Length; ++i)
        {
            if (i < star)
            {
                stars[i].gameObject.SetActive(true);
            }
            else
            {
                stars[i].gameObject.SetActive(false);
            }
        }
    }

    public void ShowAll()
    {
        characterIcon.gameObject.SetActive(true);
        starGrade.gameObject.SetActive(true);
        uiStatusHPbar.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
    }

    public void HideAll()
    {
        characterIcon.gameObject.SetActive(false);
        starGrade.gameObject.SetActive(false);
        uiStatusHPbar.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
    }
}
