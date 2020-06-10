using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIllustratedBook : MonoBehaviour
{
    [SerializeField] private UIRuneDescription uiRuneDescription = null;
    public UIRunePage uiRunePage = null;

    public void Initialize()
    {
        uiRunePage.Initialize();
        uiRuneDescription.Initialize();
    }
}
