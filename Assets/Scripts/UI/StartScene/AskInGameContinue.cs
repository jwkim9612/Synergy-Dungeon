using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AskInGameContinue : MonoBehaviour
{
    [SerializeField] private Button yesButton = null;
    [SerializeField] private Button noButton = null;

    private void Start()
    {
        yesButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.LoadInGameDataAndLoadInGameScene();
            OnHide();
        });

        noButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.RemoveInGameData();
            OnHide();
        });
    }

    private void OnHide()
    {
        gameObject.SetActive(false);
    }
}
