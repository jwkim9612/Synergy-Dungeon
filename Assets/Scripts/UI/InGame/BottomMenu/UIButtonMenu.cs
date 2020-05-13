using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonMenu : MonoBehaviour
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
        battleMenu.gameObject.SetActive(true);
        prepareMenu.SetActive(false);
    }

    private void ShowPrepareMenu()
    {
        battleMenu.gameObject.SetActive(false);
        prepareMenu.SetActive(true);
    }
}
