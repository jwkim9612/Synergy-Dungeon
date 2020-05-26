using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRunes : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UIRune uiRune;
    private List<UIRune> uiOwnedRunes;
    
    public void Initialize()
    {
        CreateOwnedRuneList();
    }

    private void CreateOwnedRuneList()
    {
        uiOwnedRunes = new List<UIRune>();

        var ownedRuneIds = RuneManager.Instance.ownedRunes;
        foreach (var ownedRuneId in ownedRuneIds)
        {
            for(int i = 0; i < ownedRuneId.Value; ++i)
            {
                var rune = Instantiate(uiRune, girdLayoutGroup.transform);
                rune.SetUIRune(GameManager.instance.dataSheet.runeDataSheet.RuneDatas[ownedRuneId.Key]);
                uiOwnedRunes.Add(rune);
            }
        }
    }

    public void AddUIRune(int runeId)
    {
        RuneData runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        var rune = Instantiate(uiRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);
        uiOwnedRunes.Add(rune);

        RuneManager.Instance.AddRune(runeId);
    }
}
