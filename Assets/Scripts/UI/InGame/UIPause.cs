using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : UIControl
{
    [SerializeField] private Button continueButton = null;
    [SerializeField] private Button mainMenuButton = null;
    [SerializeField] private UIAskBackToMainMenu uiAskBackToMainMenu = null;

    private void Start()
    {
        continueButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
            Time.timeScale = 1;
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowNew(uiAskBackToMainMenu);
        });
    }

}
