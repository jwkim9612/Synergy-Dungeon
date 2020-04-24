using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour
{
    public Transform invisibleCharacter;

    List<Arranger> arrangers;

    bool isSwapped;
    Transform swappedCharacter;

    void Start()
    {
        InitializeArrangers();

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

    void SwapCharacters(Transform source, Transform destination)
    {
        Transform sourceParent = source.parent;
        Transform destinationParent = destination.parent;

        source.SetParent(destinationParent);
        destination.SetParent(sourceParent);

        Vector3 sourcePosition = source.position;
        Vector3 destinationPosition = destination.position;

        source.position = destinationPosition;
        destination.position = sourcePosition;

        foreach (var arranger in arrangers)
        {
            arranger.UpdateChildren();
        }
    }

    void BeginDrag(Transform character)
    {
        SwapCharacters(invisibleCharacter, character);
    }

    void Drag(Transform character)
    {
        var whichArrangersCharacter = arrangers.Find(t => TransformService.ContainPos(t.transform as RectTransform, character.position));

        if (whichArrangersCharacter != null)
        {
            Transform targetCharacter = whichArrangersCharacter.GetCharacterByPosition(character);

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

    }

    void EndDrag(Transform character)
    {
        SwapCharacters(invisibleCharacter, character);
        isSwapped = false;
    }
}
