using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISynergyAndLogMenu : MonoBehaviour
{
    [SerializeField] private UIBattleSynergyList uiBattleSynergyList = null;
    [SerializeField] private UIBattleLog uiBattleLog = null;
    [SerializeField] private Button synergyListButton = null;
    [SerializeField] private Button battleLogButton = null;

    private void Start()
    {
        synergyListButton.onClick.AddListener(() =>
        {
            ShowSynergyList();
        });

        battleLogButton.onClick.AddListener(() =>
        {
            ShowBattleLog();
        });
    }

    private void ShowSynergyList()
    {
        uiBattleSynergyList.gameObject.SetActive(true);
        uiBattleLog.gameObject.SetActive(false);
    }

    private void ShowBattleLog()
    {
        uiBattleSynergyList.gameObject.SetActive(false);
        uiBattleLog.gameObject.SetActive(true);
    }




}
