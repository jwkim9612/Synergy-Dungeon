using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIObtainedRunesScreen : UIControl
{
    private List<UIObtainedRune> uiObtainedRuneList;

    public void Initialize()
    {
        uiObtainedRuneList = GetComponentsInChildren<UIObtainedRune>().ToList();
    }

    public void SetUIObtainedRuneList(List<int> runeIdList)
    {
        for(int i = 0; i < uiObtainedRuneList.Count; i++)
        {
            uiObtainedRuneList[i].SetUIObtainedRune(runeIdList[i]);
        }
    }
}
