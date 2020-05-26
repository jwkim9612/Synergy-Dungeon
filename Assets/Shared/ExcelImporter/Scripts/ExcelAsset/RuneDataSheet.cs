using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class RuneDataSheet : ScriptableObject
{
	public List<RuneData> RuneDatas;

    public void Initialize()
    {
        InitializeImage();
    }

    private void InitializeImage()
    {
        foreach (var runeData in RuneDatas)
        {
            runeData.Image = Resources.Load<Sprite>(runeData.ImagePath);
        }
    }
}
