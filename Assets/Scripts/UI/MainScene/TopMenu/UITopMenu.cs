using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITopMenu : MonoBehaviour
{
    public UIHeart uiHeart = null;
    [SerializeField] private UIGold uiGold = null;
    [SerializeField] private UIDiamond uiDiamond = null;

    private void Start()
    {
        uiHeart.Initialize();
        uiGold.Initialize();
        uiDiamond.Initialize();
    }

}
