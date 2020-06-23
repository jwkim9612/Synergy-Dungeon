using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRune : UIRune
{
    [SerializeField] private Button equipButton = null;
    [SerializeField] private GameObject clickedUIRune = null;
    [SerializeField] private Toggle toggle = null;
    public int lineIndex;
    private Vector3 originPosition;

    private void Start()
    {
        SetToggleOnClicked();
        SetEquipButton();
    }

    private void SetToggleOnClicked()
    {
        toggle.onValueChanged.AddListener((bool bOn) =>
        {
            if (bOn)
            {
                ActivateClickedRune();
                MoveToScrollPositionOfClickedRune();
            }
            else
            {
                DisableClickedRune();
            }
        });
    }

    private void MoveToScrollPositionOfClickedRune()
    {
        var scrollView = MainManager.instance.uiIllustratedBook.uiRunePage.scrollView;
        var uiOwnedRunes = MainManager.instance.uiIllustratedBook.uiRunePage.uiOwnedRunes;
        scrollView.MoveToTargetByIndex(lineIndex, uiOwnedRunes.numberOfLine, uiOwnedRunes.transform, clickedUIRune.transform);
    }

    private void ActivateClickedRune()
    {
        originPosition = clickedUIRune.transform.localPosition;

        clickedUIRune.transform.localPosition = originPosition;
        clickedUIRune.SetActive(true);
        clickedUIRune.transform.SetParent(MainManager.instance.uiIllustratedBook.transform);
    }

    private void DisableClickedRune()
    {
        var originParent = this.transform;

        clickedUIRune.transform.SetParent(originParent);
        //clickedUIRune.transform.position = originPosition;
        clickedUIRune.SetActive(false);
    }

    private void SetEquipButton()
    {
        equipButton.onClick.AddListener(() =>
        {
            toggle.isOn = false;
            EquipRuneAndSubsequentProcessing();

            Destroy(gameObject);
        });
    }

    private void EquipRuneAndSubsequentProcessing()
    {
        var runePage = MainManager.instance.uiIllustratedBook.uiRunePage;
        var equipResult = runePage.uiEquippedRunes.EquipRuneAndGetReplaceResult(this);
        if (equipResult.IsReplaced)    // 장착한 곳에 룬이 있었는지 없었는지.
        {
            SetUIRune(equipResult.EquippedRune.runeData);
            runePage.uiOwnedRunes.AddUIRune(equipResult.EquippedRune.runeData);
            runePage.uiOwnedRunes.Sort();
        }
        else
        {
            Debug.Log("교체된게 없음");
        }
    }
}