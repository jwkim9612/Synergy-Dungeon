using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRune : UIRune
{
    [SerializeField] private UIEquippedRunes uiEquippedRunes = null;
    [SerializeField] private Button equipButton = null;

    private void Start()
    {
        equipButton.onClick.AddListener(() =>
        {
            GetComponent<Toggle>().isOn = false;

            var equipResult = uiEquippedRunes.EquipRuneAndGetReplaceResult(rune);
            if(equipResult.Item1)
            {
                SetUIRune(equipResult.Item2.runeData);
                uiEquippedRunes.uiOwnedRunes.Sort();
            }
            else
            {
                Debug.Log("교체된게 없음");
                Destroy(this.gameObject);
            }
        });
    }

}
