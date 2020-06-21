using UnityEngine;

public class TransformService
{
    public static bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    public static void SetFullSize(RectTransform rt)
    {
        rt.offsetMax = new Vector2(0.0f, 0.0f);
        rt.offsetMin = new Vector2(0.0f, 0.0f);
    }
}