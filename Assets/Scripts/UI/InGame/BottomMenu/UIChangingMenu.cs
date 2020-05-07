using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangingMenu : MonoBehaviour
{
    [SerializeField] private UIBattleMenu uiBattleMenu = null;

    void Start()
    {
        uiBattleMenu.Initialize();

        InGameManager.instance.gameState.OnPrepare += uiBattleMenu.OnHide;
        InGameManager.instance.gameState.OnBattle += uiBattleMenu.OnShow;
    }
}
