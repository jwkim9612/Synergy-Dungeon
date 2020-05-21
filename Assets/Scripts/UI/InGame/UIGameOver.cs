using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Button backToMenuButton = null;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }
}
