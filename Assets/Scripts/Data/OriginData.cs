using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginData
{
    public OriginData(OriginExcelData originExcelData)
    {
        Name = originExcelData.Name;
        Description = originExcelData.Description;

        Image = Resources.Load<Sprite>(originExcelData.ImagePath);
    }

    public Origin Name;
    public string Description;
    public Sprite Image;
}
