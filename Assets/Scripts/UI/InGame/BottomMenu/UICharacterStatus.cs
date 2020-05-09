using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStatus : MonoBehaviour
{
    [SerializeField] private Image characterIcon = null;
    [SerializeField] private HorizontalLayoutGroup starGrade = null;
    [SerializeField] private UIStatusHPBar uiStatusHPbar = null;
    [SerializeField] private UIBehaviorMenu uiBehaviorMenu = null;
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

        SetCharacterIcon(uiCharacter.image);
        SetStarGrade(uiCharacter.characterInfo.star);
        ControllingPawn = uiCharacter.character;
        uiStatusHPbar.SetControllingPawn(ControllingPawn);
        uiBehaviorMenu.SetControllingPawn(ControllingPawn);
        uiBehaviorMenu.Initialize();
    }

    private void SetCharacterIcon(Image image)
    {
        characterIcon.sprite = image.sprite;
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
}
