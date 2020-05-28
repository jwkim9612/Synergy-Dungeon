using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    [SerializeField] private UIOwnedRunes uiOwnedRunes = null;
    [SerializeField] private UIEquippedRunes uiEquippedRunes = null;
    [SerializeField] private Button button1 = null;
    [SerializeField] private Button button2 = null;


    private void Start()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();

        button1.onClick.AddListener(() =>
        {
            uiOwnedRunes.AddUIRune(2001);
        });

        button2.onClick.AddListener(() =>
        {
            uiOwnedRunes.AddUIRune(1000);
        });
    }
}
