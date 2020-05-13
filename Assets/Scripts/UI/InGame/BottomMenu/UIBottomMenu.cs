using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottomMenu : MonoBehaviour
{
    [SerializeField] private UIBattleMenu battleMenu = null;
    [SerializeField] private GameObject prepareMenu = null;

    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += ShowBattleMenu;
        InGameManager.instance.gameState.OnPrepare += ShowPrepareMenu;

        battleMenu.Initialize();
    }

    private void ShowBattleMenu()
    {
        battleMenu.OnShow();
        prepareMenu.SetActive(false);
    }

    private void ShowPrepareMenu()
    {
        battleMenu.OnHide();
        prepareMenu.SetActive(true);
    }
}
