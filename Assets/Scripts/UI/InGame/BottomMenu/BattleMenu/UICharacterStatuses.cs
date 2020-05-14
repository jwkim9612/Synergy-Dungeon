using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterStatuses : MonoBehaviour
{
    public UICharacterStatus[] characterStatusList = null;

    public void Initialize()
    {
        characterStatusList = gameObject.GetComponentsInChildren<UICharacterStatus>();

        foreach (var characterStatus in characterStatusList)
        {
            characterStatus.Initialize();
        }
    }
}
