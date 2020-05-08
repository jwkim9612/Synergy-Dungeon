using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableCentral : MonoBehaviour
{
    public UICharacter invisibleCharacter;

    public UICharacterArea uiCharacterArea;
    public UIPrepareArea uiPrepareArea;
    private List<Arranger> arrangers;

    [SerializeField] private Transform Sell = null;
    bool isSelling;

    bool isSwapped;
    UICharacter swappedCharacter;

    private void Start()
    {
        InitializeArrangers();

        isSelling = false;
        isSwapped = false;
        swappedCharacter = null;
    }

    private void InitializeArrangers()
    {
        uiCharacterArea = transform.GetComponentInChildren<UICharacterArea>();
        uiPrepareArea = transform.GetComponentInChildren<UIPrepareArea>();

        arrangers = new List<Arranger>();
        arrangers.Add(uiCharacterArea);
        arrangers.Add(uiPrepareArea);
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
        Arranger whichArrangersCharacter;

        // 전투중이라면
        if (InGameManager.instance.gameState.inGameState == InGameState.Battle)
        {
            // 드래그가 준비중인 캐릭터들 위치에 있다면
            if(TransformService.ContainPos(uiPrepareArea.transform as RectTransform, character.transform.position))
            {
                whichArrangersCharacter = uiPrepareArea;
            }
            else
            {
                whichArrangersCharacter = null;
            }
        }
        else
        {
            whichArrangersCharacter = arrangers.Find(t => TransformService.ContainPos(t.transform as RectTransform, character.transform.position));
        }

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

        // Sell에 드래그했을 때
        if (TransformService.ContainPos(Sell as RectTransform, character.transform.position))
        {
            isSelling = true;
            Sell.gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isSelling = false;
            Sell.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    void EndDrag(UICharacter character)
    {
        if(isSelling)
        {
            character.DeleteCharacterBySell();
            Sell.gameObject.GetComponent<Image>().color = Color.white;
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
