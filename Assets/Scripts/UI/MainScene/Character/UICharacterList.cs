using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UICharacterSlot characterSlot = null;

    void Start()
    {
        CreateCharacterList();
        Destroy(characterSlot.gameObject);
    }

    private void CreateCharacterList()
    {
        var characterDatas = GameManager.instance.dataManager.characterDatas;
        foreach (var characterData in characterDatas)
        {
            var slot = Instantiate(characterSlot, girdLayoutGroup.transform);
            slot.SetCharacterData(characterData);
        }
    }
}
