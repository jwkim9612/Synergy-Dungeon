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
    public SortBy currentSortBy;

    public void Initialize()
    {
        currentSortBy = RuneService.DEFAULT_SORT_BY;

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
        Debug.Log("Not last");

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

    public void Sort()
    {
        UpdateOwnedRunes();

        //switch (currentSortBy)
        //{
        //    case SortBy.None:
        //        break;
        //    case SortBy.Grade:
        //        Debug.Log("Grade");
        //        uiRunes = uiRunes.OrderBy(x => x.rune.runeData.Grade).ToList();
        //        break;
        //    case SortBy.Socket:
        //        Debug.Log("socket");
        //        uiRunes = uiRunes.OrderBy(x => x.rune.runeData.SocketPosition).ToList();
        //        break;
        //    default:
        //        Debug.Log("Error Sort");
        //        return;
        //}

        //for (int i = 0; i < uiRunes.Count; ++i)
        //{
        //    uiRunes[i].transform.SetSiblingIndex(i);
        //}
    }

    public void ChangeSortBy()
    {
        if(currentSortBy == SortBy.Socket)
        {
            currentSortBy = SortBy.Grade;
        }
        else if(currentSortBy == SortBy.Grade)
        {
            currentSortBy = SortBy.Socket;
        }

        Sort();
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

        Debug.Log($"transform.childCount = {transform.childCount}     uiRunes.count = {uiRunes.Count}");

        uiRunes.RemoveRange(transform.childCount, uiRunes.Count - transform.childCount);
        Debug.Log(uiRunes.Count);

        switch (currentSortBy)
        {
            case SortBy.None:
                break;
            case SortBy.Grade:
                Debug.Log("Grade");
                uiRunes = uiRunes.OrderBy(x => x.rune.runeData.Grade).ToList();
                break;
            case SortBy.Socket:
                Debug.Log("socket");
                uiRunes = uiRunes.OrderBy(x => x.rune.runeData.SocketPosition).ToList();
                break;
            default:
                Debug.Log("Error Sort");
                break;
        }

        for (int i = 0; i < uiRunes.Count; ++i)
        {
            uiRunes[i].transform.SetSiblingIndex(i);
            Debug.Log("oh " + i);
        }
    }

    //public void UpdateOwnedRunes()
    //{
    //    for (int i = 0; i < transform.childCount; ++i)
    //    {
    //        if (i == uiRunes.Count)
    //        {
    //            uiRunes.Add(null);
    //        }

    //        var uiRune = gameObject.GetComponentsInChildren<UIOwnedRune>()[i];

    //        if (uiRune != uiRunes[i])
    //        {
    //            uiRunes[i] = uiRune;
    //        }
    //    }

    //    Debug.Log($"transform.childCount = {transform.childCount}     uiRunes.count = {uiRunes.Count}");

    //    uiRunes.RemoveRange(transform.childCount, uiRunes.Count - transform.childCount);
    //    Debug.Log(uiRunes.Count);
    //}

    private void OnDestroy()
    {
        if (RuneManager.IsAlive)
        {
            RuneManager.Instance.OnAddRune -= AddUIRune;
        }
    }
}
