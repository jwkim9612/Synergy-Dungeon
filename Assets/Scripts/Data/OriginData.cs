using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginData
{
    public OriginData(OriginExcelData originExcelData)
    {
        Origin = originExcelData.Name;
        Description = originExcelData.Description;

        Image = Resources.Load<Sprite>(originExcelData.ImagePath);
    }

    public Origin Origin;
    public string Description;
    public Sprite Image;
}
