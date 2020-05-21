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
            if (SaveManager.Instance.DeleteInGameData())
            {
                Debug.Log("Delete in game data true!");
            }
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
        });

        noButton.onClick.AddListener(() =>
        {
            UIManager.Instance.HideAndShowPreview();
        });
    }
}
