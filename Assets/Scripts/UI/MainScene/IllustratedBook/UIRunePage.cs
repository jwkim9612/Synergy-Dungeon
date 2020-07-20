using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    public UIEquippedRunes uiEquippedRunes = null;
    //public PotentialDraggableScrollView scrollView = null;
    public UIOwnedRunes uiOwnedRunes = null;
    public UIRuneInfo uiRuneInfo;

    [SerializeField] private Button changeSortByButton;
    [SerializeField] private Text changeSortByText;

    public void Initialize()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();

        SetChangeSortByButton();
    }

    private void SetChangeSortByButton()
    {
        changeSortByButton.onClick.AddListener(() =>
        {
            uiOwnedRunes.ChangeSortBy();
            SetChangeSortByText(uiOwnedRunes.currentSortBy);
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
}
