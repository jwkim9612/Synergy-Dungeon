using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;

public class UIBattlefield : MonoBehaviour
{
    public int selectedChapter = 1;

    [SerializeField] private Button playButton = null;
    [SerializeField] private Text chapterTitle = null;
    [SerializeField] private Text bestStage = null;
    [SerializeField] private Image chapterImage = null;

    void Start()
    {
        playButton.onClick.AddListener(() => {
            // 테스트를 위해 하트 소모 안하게 바꿈.
            // 나중에 밑에 3줄을 지우고 UseHeart 주석을 지워주면 됨.
            StageManager.Instance.SetChapterData(selectedChapter);
            StageManager.Instance.Initialize();
            SceneManager.LoadScene("InGameScene");
            //UseHeart();
        });

        UpdateChapterInfo();
    }

    public void UpdateChapterInfo()
    {
        UpdateChapterTitle();
        UpdateChapterImage();
        UpdateBestStage();
    }

    public void UpdateChapterTitle()
    {
        var ChapterData = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[selectedChapter];

        chapterTitle.text = ChapterData.Id + ". " + ChapterData.Name;
    }

    public void UpdateChapterImage()
    {
        chapterImage.sprite = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[selectedChapter].Image;
    }

    public void UpdateBestStage()
    {
        if (selectedChapter < PlayerDataManager.Instance.playerData.PlayableStage)
            bestStage.text = "챕터 클리어";
        else
            bestStage.text = "최고 스테이지 : " + 1 + "/" + GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[selectedChapter].TotalWave;
    }

    public void UseHeart()
    {
        new LogEventRequest()
            .SetEventKey("UseHeart")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)(response.ScriptData.GetBoolean("Result"));

                    if(result)
                    {
                        StageManager.Instance.SetChapterData(selectedChapter);
                        StageManager.Instance.Initialize();
                        SceneManager.LoadScene("InGameScene");
                    }
                    else
                    {
                        Debug.Log("No heart Man");
                    }
                }
                else
                {
                    Debug.Log("Error Use Heart"); 
                    Debug.Log(response.Errors.JSON);
                }
            });
    }
}
