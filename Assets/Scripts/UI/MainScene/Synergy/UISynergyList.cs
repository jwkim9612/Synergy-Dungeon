﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISynergyList : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UISynergySlot synergySlot = null;
    [SerializeField] private UISynergyInfo synergyInfo = null;

    void Start()
    {
        CreateSynergyList();
        Destroy(synergySlot.gameObject);

        synergyInfo.Initialize();
    }

    private void CreateSynergyList()
    {
        CreateTribeList();
        CreateOriginList();
    }

    private void CreateTribeList()
    {
        var tribeDatas = GameManager.instance.dataSheet.tribeDatas;
        foreach (var tribeData in tribeDatas)
        {
            var slot = Instantiate(synergySlot, girdLayoutGroup.transform);
            slot.SetSynergyData(tribeData);
        }
    }

    private void CreateOriginList()
    {
        var originDatas = GameManager.instance.dataSheet.originDatas;
        foreach (var originData in originDatas)
        {
            var slot = Instantiate(synergySlot, girdLayoutGroup.transform);
            slot.SetSynergyData(originData);
        }
    }
}
