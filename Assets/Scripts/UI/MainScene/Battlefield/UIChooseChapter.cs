using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class UIChooseChapter : UIControl
{
    [SerializeField] private UIBattlefield uiBattlefield = null;
    [SerializeField] private SimpleScrollSnap simpleScrollSnap = null;
    [SerializeField] private GameObject content = null;
    [SerializeField] private UIChapter uiChapter = null;
    [SerializeField] private Text chapterTitle = null;
    [SerializeField] private Button entranceButton = null;
    [SerializeField] private Button backButton = null;

    void Start()
    {
        CreateChapterList();

        entranceButton.onClick.AddListener(() => {
            uiBattlefield.selectedChapter = simpleScrollSnap.CurrentPanel + 1;
            uiBattlefield.UpdateChapterInfo();
        });

        backButton.onClick.AddListener(() => {
            simpleScrollSnap.GoToPanel(uiBattlefield.selectedChapter - 1);
        });

        simpleScrollSnap.onPanelChanged.AddListener(() =>
        {
            chapterTitle.text = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas[simpleScrollSnap.TargetPanel].Name;
            
            if(IsPlayableChapter(simpleScrollSnap.TargetPanel + 1))
            {
                entranceButton.interactable = true;
            }
            else
            {
                entranceButton.interactable = false;
            }
        });
    }

    private void CreateChapterList()
    {
        int dataIndex = 0;

        var chapterDatas = GameManager.instance.dataSheet.chapterDataSheet.ChapterDatas;
        foreach (var chapterData in chapterDatas)
        {
            if (dataIndex == 0)
            {
                uiChapter.SetChapterData(chapterData);
            }
            else
            {
                var chapter = Instantiate(uiChapter, content.transform);
                chapter.SetChapterData(chapterData);
                if (!IsPlayableChapter(dataIndex + 1))
                {
                    chapter.ToBlurry();
                }
            }

            ++dataIndex;
        }
    }

    private bool IsPlayableChapter(int chapter)
    {
        return PlayerDataManager.Instance.playerData.playableStage >= chapter ? true : false;
    }
}
