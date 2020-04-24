using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    List<Transform> children;

    void Start()
    {
        children = new List<Transform>();

        UpdateChildren();
    }

    public void UpdateChildren()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (i == children.Count)
            {
                children.Add(null);
            }

            // border안에 또 캐릭터가 있어서 GetChild를 두 번 써줌
            var child = transform.GetChild(i).GetChild(0);

            if(child != children[i])
            {
                children[i] = child;
            }
        }
  }

    public Transform GetCharacterByPosition(Transform character)
    {
        Transform targetCharacter = null;

        for(int i = 0; i < children.Count; ++i)
        { 
            if(TransformService.ContainPos(children[i] as RectTransform, character.position))
            {
                targetCharacter = children[i];
                break;
            }
        }

        return targetCharacter;
    }
}
