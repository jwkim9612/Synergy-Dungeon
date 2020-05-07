using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStatus : MonoBehaviour
{
    [SerializeField] private Image characterIcon = null;
    [SerializeField] private HorizontalLayoutGroup starGrade = null;
    private Image[] stars = null;
    
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
