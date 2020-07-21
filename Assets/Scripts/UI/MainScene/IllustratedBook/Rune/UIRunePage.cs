using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    public UIEquippedRunes uiEquippedRunes = null;
    public UIOwnedRunes uiOwnedRunes = null;
    public UIRuneInfo uiRuneInfo = null;
    public UIRuneCombination uiRuneCombination = null;

    [SerializeField] private Button changeSortByButton;
    [SerializeField] private Text changeSortByText;
    [SerializeField] private Button showRuneCombinationButton;

    public void Initialize()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();
        uiRuneCombination.Initialize();
        uiRuneInfo.Initialize();

        SetChangeSortByButton();
        SetShowRuneCombinationButton();
    }

    private void SetShowRuneCombinationButton()
    {
        showRuneCombinationButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowNew(uiRuneCombination);
        });
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
