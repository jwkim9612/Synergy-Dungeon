using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterList : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup = null;
    [SerializeField] private UICharacterSlot characterSlot = null;

    private List<UICharacterSlot> characterSlots = new List<UICharacterSlot>();

    public Cost currentCost { get; set; } = Cost.None;
    public Tribe currentTribe { get; set; } = Tribe.None;
    public Origin currentOrigin { get; set; } = Origin.None;

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
            characterSlots.Add(slot);
        }
    }

    public void Sort()
    {
        foreach (var characterSlot in characterSlots)
        {
            // 현재 정렬값이 캐릭터의 정렬값과 같지 않거나, 모든(None)값이 아니면
            if (!(characterSlot.characterData.cost == currentCost || Cost.None == currentCost))
            {
                characterSlot.gameObject.SetActive(false);
                continue;
            }

            if (!(characterSlot.characterData.tribeEnum == currentTribe || Tribe.None == currentTribe))
            {
                characterSlot.gameObject.SetActive(false);
                continue;
            }

            if (!(characterSlot.characterData.originEnum == currentOrigin || Origin.None == currentOrigin))
            {
                characterSlot.gameObject.SetActive(false);
                continue;
            }

            characterSlot.gameObject.SetActive(true);
        }
    }
}
