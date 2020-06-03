using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRunes : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UIRune uiRune;
    public List<UIRune> uiRunes;

    public void Initialize()
    {
        RuneManager.Instance.OnAddRune += AddUIRune;

        CreateOwnedRuneList();
    }

    private void CreateOwnedRuneList()
    {
        uiRunes = new List<UIRune>();

        var ownedRuneIds = RuneManager.Instance.ownedRunes;
        if (ownedRuneIds == null)
            return;

        foreach (var ownedRuneId in ownedRuneIds)
        {
            for(int i = 0; i < ownedRuneId.Value; ++i)
            {
                var rune = Instantiate(uiRune, girdLayoutGroup.transform);
                rune.SetUIRune(GameManager.instance.dataSheet.runeDataSheet.RuneDatas[ownedRuneId.Key]);
                uiRunes.Add(rune);
            }
        }

        Sort();
    }

    public void AddUIRune(int runeId)
    {
        RuneData runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        var rune = Instantiate(uiRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);

        Sort();
    }

    public void AddUIRuneByEquipRelease(int runeId)
    {
        RuneData runeData = GameManager.instance.dataSheet.runeDataSheet.RuneDatas[runeId];

        var rune = Instantiate(uiRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);

        Sort();
    }

    public void Sort()
    {
        UpdateOwnedRunes();

        uiRunes = uiRunes.OrderBy(x => x.rune.runeData.Id).ToList();

        for(int i = 0; i < uiRunes.Count; ++i)
        {
            uiRunes[i].transform.SetSiblingIndex(i);
        }
    }

    public void UpdateOwnedRunes()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (i == uiRunes.Count)
            {
                uiRunes.Add(null);
            }

            var uiRune = gameObject.GetComponentsInChildren<UIOwnedRune>()[i];

            if (uiRune != uiRunes[i])
            {
                uiRunes[i] = uiRune;
            }
        }

        uiRunes.RemoveRange(transform.childCount, uiRunes.Count - transform.childCount);
    }
}
