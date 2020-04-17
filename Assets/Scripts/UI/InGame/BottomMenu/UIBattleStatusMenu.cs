using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleStatusMenu : MonoBehaviour
{
    [SerializeField] private Button btnReload = null;
   
    [SerializeField] private UICharacterPurchase characterPurchase = null;

    void Start()
    {
        btnReload.onClick.AddListener(() => {
            characterPurchase.Shuffle();
        });
    }
}
