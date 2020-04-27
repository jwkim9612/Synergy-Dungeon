using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableCentral : MonoBehaviour
{
    public UICharacter invisibleCharacter;

    List<Arranger> arrangers;

    [SerializeField] private Transform Sell = null;
    bool isSelling;

    bool isSwapped;
    UICharacter swappedCharacter;

    void Start()
    {
        InitializeArrangers();

        isSelling = false;
        isSwapped = false;
        swappedCharacter = null;
    }

    void InitializeArrangers()
    {
        arrangers = new List<Arranger>();

        var arrs = transform.GetComponentsInChildren<Arranger>();

        for (int i = 0; i < arrs.Length; ++i)
        {
            arrangers.Add(arrs[i]);
        }
    }

    void SwapCharacters(UICharacter source, UICharacter destination)
    {
        Transform sourceTransform = source.transform;
        Transform destinationTransform = destination.transform;

        Transform sourceParent = sourceTransform.parent;
        Transform destinationParent = destinationTransform.parent;

        sourceTransform.SetParent(destinationParent);
        destinationTransform.SetParent(sourceParent);

        Vector3 sourcePosition = sourceTransform.position;
        Vector3 destinationPosition = destinationTransform.position;

        sourceTransform.position = destinationPosition;
        destinationTransform.position = sourcePosition;

        foreach (var arranger in arrangers)
        {
            arranger.UpdateChildren();
        }
    }

    void BeginDrag(UICharacter character)
    {
        SwapCharacters(invisibleCharacter, character);
    }

    void Drag(UICharacter character)
    {
        var whichArrangersCharacter = arrangers.Find(t => TransformService.ContainPos(t.transform as RectTransform, character.transform.position));

        if (whichArrangersCharacter != null)
        {
            UICharacter targetCharacter = whichArrangersCharacter.GetCharacterByPosition(character);

            if (targetCharacter != null)
            {
                if(!isSwapped)
                {
                    // 원래 자리면
                    if (targetCharacter != invisibleCharacter)
                    {
                        SwapCharacters(invisibleCharacter, targetCharacter);
                        swappedCharacter = targetCharacter;
                        isSwapped = true;
                    }
                }
                else if (isSwapped && targetCharacter != invisibleCharacter)
                {
                    if(swappedCharacter == targetCharacter)
                    {
                        SwapCharacters(invisibleCharacter, targetCharacter);
                    }
                    else
                    {
                        SwapCharacters(invisibleCharacter, swappedCharacter);
                        SwapCharacters(invisibleCharacter, targetCharacter);
                        swappedCharacter = targetCharacter;
                    }
                }
            }
        }
        else
        {
            if (isSwapped)
            {
                SwapCharacters(swappedCharacter, invisibleCharacter);
                isSwapped = false;
            }
        }

        if (TransformService.ContainPos(Sell as RectTransform, character.transform.position))
        {
            isSelling = true;
        }
        else
        {
            isSelling = false;
        }
    }

    void EndDrag(UICharacter character)
    {
        if(isSelling)
        {
            character.DeleteCharacterBySell();
        }

        SwapCharacters(invisibleCharacter, character);
        isSwapped = false;
    }

    public void CombinationCharacter(CharacterInfo characterInfo)
    {

        bool isFindFirstCharacter = false;

        foreach (var arranger in arrangers)
        {
            foreach(var uiCharacter in arranger.uiCharacters)

            if (uiCharacter.characterInfo.Equals(characterInfo))
            {
                if (!isFindFirstCharacter)
                {
                    isFindFirstCharacter = true;
                    uiCharacter.UpgradeStar();
                }
                else
                {
                    uiCharacter.DeleteCharacter();
                }
            }
        }
    }


}
