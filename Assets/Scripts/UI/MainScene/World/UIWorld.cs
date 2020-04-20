using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIWorld : MonoBehaviour
{
    public StageManager stageManager = null;
    public int selectedStage = 1;

    [SerializeField] private Button playButton = null;
    [SerializeField] private Text stageTitle = null;
    [SerializeField] private Image stageImage = null;

    void Start()
    {
        stageManager = GameManager.instance.stageManager;

        playButton.onClick.AddListener(() => {
            GameManager.instance.stageManager.Initialize();
            SceneManager.LoadScene("InGame");
        });

        UpdateStageInfo();
    }

    // selectedStage를 설정한 후 사용해주면 된다.
    public void UpdateStageInfo()
    {
        selectedStage = stageManager.currentStage;

        UpdateStageTitle();
        UpdateStageImage();
    }

    public void UpdateStageTitle()
    {
        stageTitle.text = GameManager.instance.stageManager.stageDatas[selectedStage - 1].name;
    }

    public void UpdateStageImage()
    {
        stageImage.sprite = GameManager.instance.stageManager.stageDatas[selectedStage - 1].worldImage;
    }
}
