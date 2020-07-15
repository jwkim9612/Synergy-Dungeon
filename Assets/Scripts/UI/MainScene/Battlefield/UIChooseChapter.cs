using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class UIChooseChapter : UIControl
{
    [SerializeField] private SimpleScrollSnap simpleScrollSnap = null;
    [SerializeField] private GameObject content = null;
    [SerializeField] private UIChapter uiChapter = null;
    [SerializeField] private Text chapterTitle = null;
    [SerializeField] private Button entranceButton = null;
    [SerializeField] private Button backButton = null;

    void Start()
    {
        CreateChapterList();

        var uiBattlefield = MainManager.instance.uiBattlefield;

        entranceButton.onClick.AddListener(() => {
            uiBattlefield.selectedChapter = simpleScrollSnap.CurrentPanel + 1;
            uiBattlefield.UpdateChapterInfo();
        });

        backButton.onClick.AddListener(() => {
            simpleScrollSnap.GoToPanel(uiBattlefield.selectedChapter - 1);
        });

        simpleScrollSnap.onPanelChanged.AddListener(() =>
        {
            //var chapterData = DataBase.Instance.chapterDataSheet.ChapterDatas[simpleScrollSnap.TargetPanel + 1];
            DataBase.Instance.chapterDataSheet.TryGetChapterData(simpleScrollSnap.TargetPanel + 1, out var chapterData);
            chapterTitle.text = chapterData.Id + ". " + chapterData.Name;
            
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

        if(DataBase.Instance.chapterDataSheet.TryGetChapterDatas(out var chapterDatas))
        {
            foreach (var chapterData in chapterDatas)
            {
                if (dataIndex == 0)
                {
                    uiChapter.SetChapterData(chapterData.Value);
                }
                else
                {
                    var chapter = Instantiate(uiChapter, content.transform);
                    chapter.SetChapterData(chapterData.Value);
                    if (!IsPlayableChapter(dataIndex + 1))
                    {
                        chapter.ToBlurry();
                    }
                }

                ++dataIndex;
            }
        }
        
    }

    private bool IsPlayableChapter(int chapter)
    {
        return PlayerDataManager.Instance.playerData.PlayableStage >= chapter ? true : false;
    }
}
