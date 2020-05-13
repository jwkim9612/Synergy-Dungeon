using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableCentral : MonoBehaviour
{
    public UICharacterArea uiCharacterArea;
    public UIPrepareArea uiPrepareArea;

    [SerializeField] private UICharacter invisibleCharacter = null;
    [SerializeField] private Transform SellArea = null;

    private List<Arranger> arrangers;
    private UICharacter swappedCharacter;
    private UISlot parentWhenBeginDrag;
    private float originalSize;
    private CharacterInfo selledCharacterInfo;
    private bool isSelling;
    private bool isSwapped;

    private void Start()
    {
        InitializeArrangers();

        isSelling = false;
        isSwapped = false;
        swappedCharacter = null;
        originalSize = 0.0f;
    }

    private void InitializeArrangers()
    {
        //uiCharacterArea = transform.GetComponentInChildren<UICharacterArea>();
        //uiPrepareArea = transform.GetComponentInChildren<UIPrepareArea>();

        arrangers = new List<Arranger>();
        arrangers.Add(uiCharacterArea.backArea);
        arrangers.Add(uiCharacterArea.frontArea);
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

        source.FollowCharacter();
        destination.FollowCharacter();

        TransformService.SetFullSize(source.transform as RectTransform);
        TransformService.SetFullSize(destination.transform as RectTransform);

        foreach (var arranger in arrangers)
        {
            arranger.UpdateChildren();
        }
    }

    void BeginDrag(UICharacter uiCharacter)
    {
        parentWhenBeginDrag = uiCharacter.GetComponentInParent<UISlot>();
        SwapCharacters(invisibleCharacter, uiCharacter);
        originalSize = uiCharacter.character.GetSize();
        SellArea.gameObject.SetActive(true);
    }

    void Drag(UICharacter uiCharacter)
    {
        Arranger whichArrangersCharacter;

        // 전투중이라면
        //if (InGameManager.instance.gameState.inGameState == InGameState.Battle)
        //{
        //    // 드래그가 준비중인 캐릭터들 위치에 있다면
        //    if (TransformService.ContainPos(uiPrepareArea.transform as RectTransform, uiCharacter.transform.position))
        //    {
        //        whichArrangersCharacter = uiPrepareArea;
        //    }
        //    else
        //    {
        //        whichArrangersCharacter = null;
        //    }
        //}
        //else
        //{
        //    whichArrangersCharacter = arrangers.Find(t => TransformService.ContainPos(t.transform as RectTransform, uiCharacter.transform.position));
        //}

        whichArrangersCharacter = arrangers.Find(t => TransformService.ContainPos(t.transform as RectTransform, uiCharacter.transform.position));

        if (whichArrangersCharacter != null)
        {
            UICharacter targetCharacter = whichArrangersCharacter.GetCharacterByPosition(uiCharacter);

            if (targetCharacter != null)
            {
                if (!isSwapped)
                {
                    // 옆으로 옮기면
                    if (targetCharacter != invisibleCharacter)
                    {
                        SwapCharacters(invisibleCharacter, targetCharacter);
                        swappedCharacter = targetCharacter;
                        isSwapped = true;
                    }
                }
                else
                {
                    if(targetCharacter == swappedCharacter)
                    {
                        SwapCharacters(invisibleCharacter, targetCharacter);
                        isSwapped = false;
                    }
                    else if(targetCharacter != invisibleCharacter)
                    {
                        SwapCharacters(invisibleCharacter, swappedCharacter);
                        SwapCharacters(invisibleCharacter, targetCharacter);
                        swappedCharacter = targetCharacter;
                    }
                }

                // 캐릭터 크기 조정
                if (TransformService.ContainPos(uiCharacterArea.transform as RectTransform, uiCharacter.transform.position))
                {
                    uiCharacter.character.SetSize(CharacterService.SIZE_IN_BATTLE_AREA);
                }
                else if (TransformService.ContainPos(uiPrepareArea.transform as RectTransform, uiCharacter.transform.position))
                {
                    uiCharacter.character.SetSize(CharacterService.SIZE_IN_PREPARE_AREA);
                }
            }
        }
        else
        {
            if (isSwapped)
            {
                uiCharacter.character.SetSize(originalSize);
                SwapCharacters(swappedCharacter, invisibleCharacter);
                isSwapped = false;
            }
        }

        // Sell에 드래그했을 때
        if (TransformService.ContainPos(SellArea as RectTransform, uiCharacter.transform.position))
        {
            isSelling = true;
            SellArea.gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isSelling = false;
            SellArea.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    void EndDrag(UICharacter uiCharacter)
    {
        if(isSelling)
        {
            selledCharacterInfo = uiCharacter.DeleteCharacterBySell();
            SellArea.gameObject.GetComponent<Image>().color = Color.white;
        }
        SellArea.gameObject.SetActive(false);

        SwapCharacters(invisibleCharacter, uiCharacter);
        UpdateSynergyService(uiCharacter);

        isSwapped = false;
    }

    public void CombinationCharacter(CharacterInfo characterInfo)
    {

        bool isFirstCharacter = true;

        foreach (var arranger in arrangers)
        {
            foreach(var uiCharacter in arranger.uiCharacters)

            if (uiCharacter.characterInfo.Equals(characterInfo))
            {
                InGameManager.instance.synergyService.SubCharacterFromCombinations(uiCharacter, isFirstCharacter);

                if (isFirstCharacter)
                {
                    isFirstCharacter = false;
                    uiCharacter.UpgradeStar();
                }
                else
                {
                    uiCharacter.DeleteCharacter();
                }
            }
        }
    }

    // 시너지서비스에 넣어주기
    public void UpdateSynergyService(UICharacter uiCharacter)
    {
        if(uiCharacter.GetComponentInParent<UISlot>() == parentWhenBeginDrag)
        {
            return;
        }

        if (uiCharacter.GetArea<UICharacterArea>() != null && isSelling)
        {
            InGameManager.instance.synergyService.SubCharacter(selledCharacterInfo);
            return;
        }

        //CharacterArea에서 PrepareArea로 바꿨을 경우
            if (uiCharacter.GetArea<UIPrepareArea>() != null && swappedCharacter.GetArea<UICharacterArea>() != null)
        {
            if (swappedCharacter.character == null)
            {
                // uiCharacter를 하나 빼준다.
                InGameManager.instance.synergyService.SubCharacter(uiCharacter.characterInfo);
            }
            else
            {
                // uiCharacter를 하나 빼주고,
                InGameManager.instance.synergyService.SubCharacter(uiCharacter.characterInfo);
                InGameManager.instance.synergyService.AddCharacter(swappedCharacter.characterInfo);
                // swappedCharacter를 하나 더해준다.
            }
        }
        // PrepareArea에서 CharacterArea로 바꿨을 경우
        else if (uiCharacter.GetArea<UICharacterArea>() != null && swappedCharacter.GetArea<UIPrepareArea>() != null)
        {
            if (swappedCharacter.character == null)
            {
                InGameManager.instance.synergyService.AddCharacter(uiCharacter.characterInfo);
                // uicharacter를 하나 더해준다.
            }
            else
            {
                // uicharacter를 하나 더해주고
                InGameManager.instance.synergyService.AddCharacter(uiCharacter.characterInfo);
                InGameManager.instance.synergyService.SubCharacter(swappedCharacter.characterInfo);
                // swapped를 하나 빼준다.
            }
        }
    }


}
