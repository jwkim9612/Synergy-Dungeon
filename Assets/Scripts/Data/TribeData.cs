using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribeData
{
    public TribeData(TribeExcelData tribeExcelData)
    {
        Tribe = tribeExcelData.Name;
        Description = tribeExcelData.Description;

        Image = Resources.Load<Sprite>(tribeExcelData.ImagePath);
    }

    public Tribe Tribe;
    public string Description;
    public Sprite Image;
}
