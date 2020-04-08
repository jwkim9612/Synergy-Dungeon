using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    [SerializeField] private Button resetButton = null;

    // Start is called before the first frame update
    void Start()
    {
        resetButton.onClick.AddListener(() => {
            GameManager.instance.dataManager.Reset();
            SceneManager.LoadScene("StartScene");
        });
    }
}