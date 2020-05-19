using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBattlefield : MonoBehaviour
{
    public int selectedChapter = 1;

    [SerializeField] private Button playButton = null;
    [SerializeField] private Text chapterTitle = null;
    [SerializeField] private Image chapterImage = null;

    void Start()
    {
        playButton.onClick.AddListener(() => {
            StageManager.Instance.SetChapterData(selectedChapter);
            SceneManager.LoadScene("InGame");
        });

        UpdateChapterInfo();
    }

    // selectedStage를 설정한 후 사용해주면 된다.
    public void UpdateChapterInfo()
    {
        //selectedStage = StageManager.Instance.currentStage;

        UpdateChapterTitle();
        UpdateChapterImage();
    }

    public void UpdateChapterTitle()
    {
        chapterTitle.text = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[selectedChapter - 1].Name;
    }

    public void UpdateChapterImage()
    {
        chapterImage.sprite = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[selectedChapter - 1].Image;
    }
}
