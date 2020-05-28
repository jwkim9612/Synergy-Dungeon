﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedRunes : MonoBehaviour
{
    public UIOwnedRunes uiOwnedRunes;
    public List<UIEquipRune> uiEquippedRunes;

    public void Initialize()
    {
        uiEquippedRunes = GetComponentsInChildren<UIEquipRune>().ToList();

        InitializeEquippedRunes();
    }

    // 로컬에서 장착된 룬 리스트를 가져온 후 소유한 룬에서 하나씩 장착.
    private void InitializeEquippedRunes()
    {
        List<int> equippedRuneIds = SaveManager.Instance.equippedRuneIdsSaveData;
        for (int i = 0; i < equippedRuneIds.Count; ++i)
        {
            if (equippedRuneIds[i] == -1)
            {
                uiEquippedRunes[i].Disable();
                continue;
            }

            var runeToBeEquipped = uiOwnedRunes.uiRunes.Find(x => x.rune.runeData.Id == equippedRuneIds[i]);
            if (runeToBeEquipped != null)
            {
                EquipRuneAndGetReplaceResult(runeToBeEquipped.rune);
                Destroy(runeToBeEquipped.gameObject);
            }
            else
                Debug.Log("장착되었던 룬을 찾을 수 없습니다.");
        }
    }

    /// <summary>
    /// 룬 장착 함수
    /// </summary>
    /// <param name="runeDataToEquip"> 장착할 룬의 데이터</param>
    /// <returns>교체 되었는지의 Bool값과 교체되었다면 교체된 RuneData, 교체가 안되었다면 null값을 가진 Tuple을 리턴</returns>
    public Tuple<bool, Rune> EquipRuneAndGetReplaceResult(Rune runeToEquip)
    {
        bool isReplaced;
        Rune equippedRune;

        int socketPositionOfRuneDataToEquip = runeToEquip.runeData.SocketPosition;
        UIEquipRune uiEquipRuneToBeEquip = uiEquippedRunes[socketPositionOfRuneDataToEquip];

        // 장착할 위치에 룬이 없는경우
        if (uiEquipRuneToBeEquip.rune == null)
        {
            isReplaced = false;
            equippedRune = null;
            uiEquippedRunes[socketPositionOfRuneDataToEquip].GetComponent<Toggle>().interactable = true;
        }
        else
        {
            isReplaced = true;
            equippedRune = uiEquipRuneToBeEquip.rune;
        }

        uiEquippedRunes[socketPositionOfRuneDataToEquip].SetUIRune(runeToEquip.runeData);
        SaveManager.Instance.SetEquippedRuneIdsSaveData(socketPositionOfRuneDataToEquip, runeToEquip.runeData.Id);
        SaveManager.Instance.SaveEquippedRuneIds();
        RuneManager.Instance.uiEquippedRunes = uiEquippedRunes;

        return new Tuple<bool, Rune>(isReplaced, equippedRune);
    }
}