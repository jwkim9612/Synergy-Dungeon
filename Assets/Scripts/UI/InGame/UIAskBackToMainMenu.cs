using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIAskBackToMainMenu : UIControl
{
    [SerializeField] private Button yesButton = null; 
    [SerializeField] private Button noButton = null; 

    private void Start()
    {
        yesButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });

        noButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
        });

    }
}
