using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITopMenu : MonoBehaviour
{
    [SerializeField] private UIHeart uiHeart;
    [SerializeField] private UIGold uiGold;
    [SerializeField] private UIDiamond uiDiamond;

    private void Start()
    {
        uiHeart.Initialize();
        uiGold.Initialize();
        uiDiamond.Initialize();
    }

}
