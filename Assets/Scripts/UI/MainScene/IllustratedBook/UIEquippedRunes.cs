using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIEquippedRunes : MonoBehaviour
{
    private List<UIRune> uiEquippedRunes;

    public void Initialize()
    {
        uiEquippedRunes = GetComponentsInChildren<UIRune>().ToList();

        // 로컬에서 장착된 룬 리스트를 가져온 후 소유한 룬에서 하나씩 장착.
    }
}
