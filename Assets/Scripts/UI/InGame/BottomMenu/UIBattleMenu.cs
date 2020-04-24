using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleMenu : MonoBehaviour
{
    

    //void Start()
    //{
    //    InGameManager.instance.gameState.OnPrepare += OnHide;
    //    InGameManager.instance.gameState.OnBattle += OnShow;
    //}

    public void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }
}
