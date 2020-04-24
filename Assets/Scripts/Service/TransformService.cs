using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformService
{
    public static bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }
}