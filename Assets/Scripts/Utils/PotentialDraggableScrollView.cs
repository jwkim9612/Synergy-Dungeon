using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using Org.BouncyCastle.Asn1.X509;

public class PotentialDraggableScrollView : ScrollRect
{
    private bool routeToParent = false;


    /// <summary>
    /// Do action for all parents
    /// </summary>
    private void DoForParents<T>(Action<T> action) where T : IEventSystemHandler
    {
        Transform parent = transform.parent;
        while (parent != null)
        {
            foreach (var component in parent.GetComponents<Component>()) {
                if (component is T)
                    action((T)(IEventSystemHandler)component);
            }
            parent = parent.parent;
        }
    }

    /// <summary>
    /// Always route initialize potential drag event to parents
    /// </summary>
    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        DoForParents<IInitializePotentialDragHandler>((parent) => { parent.OnInitializePotentialDrag(eventData); });
        base.OnInitializePotentialDrag(eventData);
    }

    /// <summary>
    /// Drag event
    /// </summary>
    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (routeToParent)
            DoForParents<IDragHandler>((parent) => { parent.OnDrag(eventData); });
        else
            base.OnDrag(eventData);
    }

    /// <summary>
    /// Begin drag event
    /// </summary>
    public override void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (!horizontal && Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
            routeToParent = true;
        else if (!vertical && Math.Abs(eventData.delta.x) < Math.Abs(eventData.delta.y))
            routeToParent = true;
        else
            routeToParent = false;

        if (routeToParent)
            DoForParents<IBeginDragHandler>((parent) => { parent.OnBeginDrag(eventData); });
        else
            base.OnBeginDrag(eventData);
    }

    /// <summary>
    /// End drag event
    /// </summary>
    public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (routeToParent)
            DoForParents<IEndDragHandler>((parent) => { parent.OnEndDrag(eventData); });
        else
            base.OnEndDrag(eventData);
        routeToParent = false;
    }

    public void GoToTarget(RectTransform target)
    {
        StartCoroutine(Co_GoToTarget(target));
    }

    IEnumerator Co_GoToTarget(RectTransform target)
    {
        while (!Input.GetMouseButton(0))
        {
            verticalNormalizedPosition = Mathf.Lerp(verticalNormalizedPosition, 1 + (target.localPosition.y / content.rect.height), 0.1f);
            yield return new WaitForEndOfFrame();
        }
    }

    public void GoToTargetByIndex(int targetIndex, int totalIndex)
    {
        float destinationPosition = 1.0f;

        if (targetIndex == 0)
            destinationPosition = 1.0f;
        else if (targetIndex == totalIndex - 1 || targetIndex == totalIndex -2)
            destinationPosition = 0.0f;
        else
        {
            float addValue = 1.0f / ((float)totalIndex - 2);
            for(int i = 1; i < totalIndex; ++i)
            {
                destinationPosition -= addValue;
                if (i == targetIndex)
                    break;
            }
        }

        Debug.Log(destinationPosition);
        StartCoroutine(Co_GoToTargetByIndex(destinationPosition));
    }

    IEnumerator Co_GoToTargetByIndex(float destinationPosition)
    {
        while (!Input.GetMouseButton(0))
        {
            this.verticalNormalizedPosition = Mathf.Lerp(this.verticalNormalizedPosition, destinationPosition, 0.1f);
            yield return new WaitForEndOfFrame();
        }
    }
}