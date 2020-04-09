using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UICharacterSlot characterSlot = null;
    [SerializeField] private ScrollRect scrollRect = null;

    // Start is called before the first frame update
    void Start()
    {
        var characterDatas = GameManager.instance.dataManager.characterDatas;
        foreach (var characterData in characterDatas)
        {
            var slot = Instantiate(characterSlot, girdLayoutGroup.transform);
            slot.setName(characterData.name);
        }

        characterSlot.SetActive(false);

        //foreach (var characterData in characterDatas)
        //{
        //    Debug.Log($"Name : {characterData.name}\tTribe : {characterData.tribeStr}\tOrigin : {characterData.originStr}");
        //}

    }
}
