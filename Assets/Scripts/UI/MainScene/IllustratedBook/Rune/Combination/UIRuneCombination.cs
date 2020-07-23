using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIRuneCombination : UIControl
{
    public UICombinationSpace uiCombinationSpace = null;
    public UIRunesForCombination uiRunesForCombination = null;
    public Button combinationButton = null;

    public void Initialize()
    {
        uiCombinationSpace.Initialize();
        uiRunesForCombination.Initialize();

        SetCombinationButton();
        HideCombinationButton();
    }

    public void Reset()
    {
        uiCombinationSpace.Reset();
        uiRunesForCombination.Reset();
    }

    private void SetCombinationButton()
    {
        combinationButton.onClick.AddListener(() =>
        {
            var runeIdAndIsEquippedList = uiCombinationSpace.GetRuneIdAndIsEquippedList();

            foreach (var runeIdAndIsEquipped in runeIdAndIsEquippedList)
            {
                var runeId = runeIdAndIsEquipped.runeId;
                var isEquipped = runeIdAndIsEquipped.IsEquipped;

                RuneManager.Instance.RemoveRune(runeId, isEquipped);
            }

            Reset();

            /// 조합 과정 ///
            RuneGrade combinationGrade = uiCombinationSpace.combinationGrade;

            // 조합된 룬 등급에서 한 단계 업그레이드 된 등급
            int randomId = RuneService.GetRandomIdByGrade(combinationGrade + 1);

            RuneManager.Instance.AddRune(randomId);
            var uiObtainedRuneByCombinationScreen = MainManager.instance.uiIllustratedBook.uiObtainedRuneByCombinationScreen;
            
            uiObtainedRuneByCombinationScreen.SetUIObtainedScreen(randomId);
            UIManager.Instance.ShowNew(uiObtainedRuneByCombinationScreen);
        });
    }

    public void ShowCombinationButton()
    {
        combinationButton.gameObject.SetActive(true);
    }

    public void HideCombinationButton()
    {
        combinationButton.gameObject.SetActive(false);
    }
}
