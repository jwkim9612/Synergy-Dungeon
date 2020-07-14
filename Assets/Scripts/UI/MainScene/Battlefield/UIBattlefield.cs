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
    [SerializeField] private Image potionImage = null;

    void Start()
    {
        playButton.onClick.AddListener(() => {
            // 테스트를 위해 하트 소모 안하게 바꿈.
            // 나중에 밑에 3줄을 지우고 UseHeart 주석을 지워주면 됨.
            //StageManager.Instance.SetChapterData(selectedChapter);
            //StageManager.Instance.Initialize();
            //SceneManager.LoadScene("InGameScene");
            var uiHeart = MainManager.instance.uiTopMenu.uiHeart;
            if (uiHeart.HasHeart())
            {
                UseHeart();
            }
            else
            {
                MainManager.instance.uiAskGoToStore.SetText(PurchaseCurrency.Heart);
                UIManager.Instance.ShowNew(MainManager.instance.uiAskGoToStore);
            }
        });

        UpdateChapterInfo();
        UpdatePotionImage();
    }

    public void UpdatePotionImage()
    {
        if(PotionManager.Instance.HasPotionInUse())
        {
            var potionDataSheet = DataBase.Instance.potionDataSheet;
            if(potionDataSheet == null)
            {
                Debug.Log("potionDataSheet is null!");
                return;
            }

            var potionId = PotionManager.Instance.potionIdInUse;
            if(potionDataSheet.TryGetPotionImage(potionId, out var image))
            {
                potionImage.sprite = image;
            }
        }
        else
        {
            potionImage.sprite = null;
        }
    }

    public void UpdateChapterInfo()
    {
        UpdateChapterTitle();
        UpdateChapterImage();
        UpdateBestWave();
    }

    public void UpdateChapterTitle()
    {
        var chapterDataSheet = DataBase.Instance.chapterDataSheet;
        if (chapterDataSheet == null)
        {
            Debug.LogError("Error chapterDataSheet is null");
            return;
        }

        if (!chapterDataSheet.TryGetChapterId(selectedChapter, out var id))
        {
            return;
        }
        if(!chapterDataSheet.TryGetChapterName(selectedChapter, out var title))
        {
            return;
        }

        chapterTitle.text = id + ". " + title;
    }

    public void UpdateChapterImage()
    {
        var chapterDataSheet = DataBase.Instance.chapterDataSheet;
        if (chapterDataSheet == null)
        {
            Debug.LogError("Error chapterDataSheet is null");
            return;
        }

        if(chapterDataSheet.TryGetChapterImage(selectedChapter, out var sprite))
        {
            chapterImage.sprite = sprite;
        }
    }

    public void UpdateBestWave()
    {
        if (selectedChapter < PlayerDataManager.Instance.playerData.PlayableStage)
            bestStage.text = "챕터 클리어";
        else
        {
            var chapterDataSheet = DataBase.Instance.chapterDataSheet;
            if(chapterDataSheet == null) 
            { 
                Debug.LogError("Error chapterDataSheet is null");
                return;
            }

            if (chapterDataSheet.TryGetChapterTotalWave(selectedChapter, out var totalWave))
            {
                var playerData = PlayerDataManager.Instance.playerData;
                bestStage.text = $"최고 웨이브 : {playerData.TopWave}/{totalWave}";
            }
        }
    }

    public void UseHeart()
    {
        MainManager.instance.ShowEnteringDungeon();

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
                        MainManager.instance.HideEnteringDungeon();
                        Debug.Log("Error Use Heart!!");
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
