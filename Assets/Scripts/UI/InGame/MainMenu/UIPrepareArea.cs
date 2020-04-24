using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrepareArea : MonoBehaviour
{
    List<UISlot> uiSlots;

    void Start()
    {
        uiSlots = new List<UISlot>();

        var slots = gameObject.GetComponentsInChildren<UISlot>();
        
        for(int i = 0; i < slots.Length; ++i)
        {
            uiSlots.Add(slots[i]);
        }
    }

    public bool BuyCharacter(int characterIndex)
    {
        foreach(var uiSlot in uiSlots)
        {
            if(uiSlot.HasCharacter())
            {
                continue;
            }
            else
            {
                uiSlot.SetUICharacter(characterIndex);
                return true;
            }
        }

        return false;
    }
}
