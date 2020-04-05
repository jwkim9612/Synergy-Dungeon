using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainExit : UIControl
{
    [SerializeField] private Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(() => {
            GameManager.instance.Quit();
        });
    }
}
