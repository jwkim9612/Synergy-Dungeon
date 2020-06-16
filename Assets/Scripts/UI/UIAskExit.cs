using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAskExit : UIControl
{
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    void Start()
    {
        yesButton.onClick.AddListener(() =>
        {
            GameManager.instance.Quit();
        });

        noButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
        });
    }
}
