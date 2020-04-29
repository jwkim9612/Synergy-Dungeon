﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    Camera mainCamera;
    //[SerializeField] private UICharacter uiCharacter;
    UICharacter uiCharacter;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        root = transform.root;

        uiCharacter = GetComponent<UICharacter>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
        root.BroadcastMessage("BeginDrag", uiCharacter, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        //mousePosition의 좌표를 카메라의 월드 좌표로 변환
        currentPos = mainCamera.ScreenToWorldPoint(currentPos);

        transform.position = currentPos;
        //root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
        root.BroadcastMessage("Drag", uiCharacter, SendMessageOptions.DontRequireReceiver);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        root.BroadcastMessage("EndDrag", uiCharacter, SendMessageOptions.DontRequireReceiver);
    }
}