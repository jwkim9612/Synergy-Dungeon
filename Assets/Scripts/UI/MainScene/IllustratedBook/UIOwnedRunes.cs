using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRunes : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UIOwnedRune uiOwnedRune = null;
    public List<UIOwnedRune> uiRunes { get; set; }
    public int numberOfLine;

    public void Initialize()
    {
        RuneManager.Instance.OnAddRune += AddUIRune;

        CreateOwnedRuneList();
    }

    private void CreateOwnedRuneList()
    {
        uiRunes = new List<UIOwnedRune>();

        var ownedRuneIds = RuneManager.Instance.ownedRunes;
        if (ownedRuneIds == null)
            return;

        foreach (var ownedRuneId in ownedRuneIds)
        {
            for(int i = 0; i < ownedRuneId.Value; ++i)
            {
                var runeDataSheet = DataBase.Instance.runeDataSheet;
                if (runeDataSheet == null)
                {
                    Debug.LogError("Error runeDataSheet is null");
                    return;
                }

                if(runeDataSheet.TryGetRuneData(ownedRuneId.Key, out var runeData))
                {
                    var rune = Instantiate(uiOwnedRune, girdLayoutGroup.transform);
                    rune.SetUIRune(runeData);
                    uiRunes.Add(rune);
                }
            }
        }

        Sort();
    }

    public void AddUIRune(int runeId)
    {
        var runeDataSheet = DataBase.Instance.runeDataSheet;
        if (runeDataSheet == null)
        {
            Debug.LogError("Error runeDataSheet is null");
            return;
        }

        if (runeDataSheet.TryGetRuneData(runeId, out var runeData))
        {
            var rune = Instantiate(uiOwnedRune, girdLayoutGroup.transform);
            rune.SetUIRune(runeData);
            uiRunes.Add(rune);

            Sort();
        }
    }

    public void AddUIRune(RuneData runeData)
    {
        var rune = Instantiate(uiOwnedRune, girdLayoutGroup.transform);
        rune.SetUIRune(runeData);
        uiRunes.Add(rune);

        Sort();
    }

    public void RemoveRune(UIOwnedRune uiOwnedRune)
    {
        uiRunes.Remove(uiOwnedRune);
    }

    //public void AddUIRuneByEquipRelease(int runeId)
    //{
    //    var runeDataSheet = DataBase.Instance.runeDataSheet;
    //    if (runeDataSheet == null)
    //    {
    //        Debug.LogError("Error runeDataSheet is null");
    //        return;
    //    }

    //    if (runeDataSheet.TryGetRuneData(runeId, out var runeData))
    //    {
    //        var rune = Instantiate(uiOwnedRune, girdLayoutGroup.transform);
    //        rune.SetUIRune(runeData);
    //        uiRunes.Add(rune);

    //        Sort();
    //    }
    //}

    public void Sort()
    {
        UpdateOwnedRunes();

        int runeIndex;
        uiRunes = uiRunes.OrderBy(x => x.rune.runeData.Id).ToList();

        for(int i = 0; i < uiRunes.Count; ++i)
        {
            runeIndex = i / RuneService.TOTAL_NUMBER_PER_LINE;
            uiRunes[i].transform.SetSiblingIndex(i);
            uiRunes[i].lineIndex = runeIndex;
        }

        numberOfLine = uiRunes.Count / RuneService.TOTAL_NUMBER_PER_LINE + 1;
        if (uiRunes.Count % 7 == 0)
            numberOfLine -= 1;
    }

    public void UpdateOwnedRunes()
    {
        StartCoroutine(Co_UpdateOwnedRunes());
    }

    private IEnumerator Co_UpdateOwnedRunes()
    {
        yield return new WaitForEndOfFrame();

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

    private void OnDestroy()
    {
        if (RuneManager.IsAlive)
        {
            RuneManager.Instance.OnAddRune -= AddUIRune;
        }
    }
}
