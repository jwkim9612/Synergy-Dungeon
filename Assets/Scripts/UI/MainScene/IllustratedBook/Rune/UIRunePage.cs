﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    public UIEquippedRunes uiEquippedRunes = null;
    public UIRunesOnRunePage uiRunesOnRunePage = null;
    public UIRuneInfo uiRuneInfo = null;
    public UIRuneCombination uiRuneCombination = null;

    [SerializeField] private Image noticeImage = null;


    [SerializeField] private Button changeSortByButton;
    [SerializeField] private Text changeSortByText;
    [SerializeField] private Button showRuneCombinationButton;

    public void Initialize()
    {
        uiRunesOnRunePage.Initialize();
        uiRuneCombination.Initialize();
        uiEquippedRunes.Initialize();
        uiRuneInfo.Initialize();

        SetChangeSortByButton();
        SetShowRuneCombinationButton();
    }

    private void SetShowRuneCombinationButton()
    {
        showRuneCombinationButton.onClick.AddListener(() =>
        {
            uiRuneCombination.Reset();
            UIManager.Instance.ShowNew(uiRuneCombination);
        });
    }

    private void SetChangeSortByButton()
    {
        changeSortByButton.onClick.AddListener(() =>
        {
            uiRunesOnRunePage.ChangeSortBy();
            SetChangeSortByText(uiRunesOnRunePage.currentSortBy);
        });
    }

    private void SetChangeSortByText(SortBy sortBy)
    {
        switch (sortBy)
        {
            case SortBy.None:
                break;
            case SortBy.Grade:
                changeSortByText.text = RuneService.TEXT_OF_SORT_BY_GRADE;
                break;
            case SortBy.Socket:
                changeSortByText.text = RuneService.TEXT_OF_SORT_BY_SOCKET;
                break;
            default:
                break;
        }
    }

    public void ShowNotice()
    {
        noticeImage.gameObject.SetActive(true);
    }

    public void HideNotice()
    {
        noticeImage.gameObject.SetActive(false);
    }

    public void CheckNotify()
    {
        var uiRunePage = MainManager.instance.uiIllustratedBook.uiRunePage;

        if (RuneManager.Instance.CanCombination())
        {
            uiRunePage.ShowNotice();
        }
        else
        {
            uiRunePage.HideNotice();
        }
    }
}