using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRunes : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UIRune uiRune;
    public List<UIRune> uiRunes;
    
    public void Initialize()
    {
        CreateOwnedRuneList();
    }

    private void CreateOwnedRuneList()
    {
        uiRunes = new List<UIRune>();

        var ownedRuneIds = RuneManager.Instance.ownedRunes;
        foreach (var ownedRuneId in ownedRuneIds)
        {
            for(int i = 0; i < ownedRuneId.Value; ++i)
            {
                var rune = Instantiate(uiRune, girdLayoutGroup.transform);
                rune.SetUIRune(GameManager.instance.dataSheet.runeDataSheet.RuneDatas[ownedRuneId.Key]);
                uiRunes.Add(rune);
            }
        }
    }

    public void AddUIRune(int runeId)
    {
        RuneData runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        var rune = Instantiate(uiRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);
        uiRunes.Add(rune);

        RuneManager.Instance.AddRune(runeId);
    }

    public void AddUIRuneByEquipRelease(int runeId)
    {
        RuneData runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        var rune = Instantiate(uiRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);
    }
}
