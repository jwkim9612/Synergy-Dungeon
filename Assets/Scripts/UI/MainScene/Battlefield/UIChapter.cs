using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIChapter : MonoBehaviour
{
    [SerializeField] private Image image = null;

    public ChapterData chapterData { get; set; }

    public void SetChapterData(ChapterData newChapterData)
    {
        chapterData = newChapterData;

        SetImage(chapterData.Image);
    }

    public void SetImage(Sprite sprite)
    {
        if (sprite != null)
        {
            image.sprite = sprite;
        }
        else
        {
            Debug.Log("No Image");
        }
    }

    public void ToBlurry()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.g, InGameService.SIZE_TO_BLUR);
    }
}
