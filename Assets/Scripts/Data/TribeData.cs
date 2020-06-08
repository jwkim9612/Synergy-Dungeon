using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribeData
{
    public TribeData(TribeExcelData tribeExcelData)
    {
        Name = tribeExcelData.Name;
        Description = tribeExcelData.Description;

        Image = Resources.Load<Sprite>(tribeExcelData.ImagePath);
    }

    public Tribe Name;
    public string Description;
    public Sprite Image;
}
