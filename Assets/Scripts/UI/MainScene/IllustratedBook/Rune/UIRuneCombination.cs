using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRuneCombination : UIControl
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UIOwnedRune uiOwnedRune = null;

    public void Initialize()
    {
        //uiRunes = new List<UIOwnedRune>();

        var ownedRuneIds = RuneManager.Instance.ownedRunes;
        if (ownedRuneIds == null)
            return;

        foreach (var ownedRuneId in ownedRuneIds)
        {
            for (int i = 0; i < ownedRuneId.Value; ++i)
            {
                var runeDataSheet = DataBase.Instance.runeDataSheet;
                if (runeDataSheet == null)
                {
                    Debug.LogError("Error runeDataSheet is null");
                    return;
                }

                if (runeDataSheet.TryGetRuneData(ownedRuneId.Key, out var runeData))
                {
                    var rune = Instantiate(uiOwnedRune, girdLayoutGroup.transform);
                    rune.SetUIRune(runeData);
                    //uiRunes.Add(rune);
                }
            }
        }

        //Sort();
    }

}
