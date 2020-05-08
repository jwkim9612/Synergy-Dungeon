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
            GameManager.instance.stageManager.currentStage = SaveManager.Instance.LoadInGameData().Stage;
            GameManager.instance.stageManager.Initialize();
            GameManager.instance.stageManager.currentWave = SaveManager.Instance.LoadInGameData().Wave;
            SceneManager.LoadScene("InGame");
        });

        noButton.onClick.AddListener(() =>
        {
            if(SaveManager.Instance.DeleteInGameData())
            {
                Debug.Log("Delete in game data true!");
            }
            SceneManager.LoadScene("MainScene");
        });
    }


}
