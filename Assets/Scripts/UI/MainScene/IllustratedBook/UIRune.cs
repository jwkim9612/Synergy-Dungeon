using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRune : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Button showRuneInfoButton;

    public bool isEquippedRune;

    public Rune rune { get; set; }

    private void Start()
    {
        SetShowRuneInfoButton();
    }

    public virtual void SetUIRune(RuneData newRuneData)
    {
        rune = new Rune();
        rune.SetRune(newRuneData);

        SetImage(newRuneData.Image);
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    private void SetShowRuneInfoButton()
    {
        showRuneInfoButton.onClick.AddListener(() =>
        {
            var uiRuneInfo = MainManager.instance.uiIllustratedBook.uiRunePage.uiRuneInfo;
            uiRuneInfo.SetUIRuneInfo(rune.runeData, isEquippedRune, this);
            UIManager.Instance.ShowNew(uiRuneInfo);
        });
    }

    protected void SetShowRuneInfoButtonInteractable(bool isInteractable)
    {
        if(isInteractable)
        {
            showRuneInfoButton.interactable = true;
        }
        else
        {
            showRuneInfoButton.interactable = false;
        }
    }
}
