using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    public CharacterData(CharacterExcelData characterExcelData)
    {
        Id = characterExcelData.Id;
        Name = characterExcelData.Name;
        Tribe = characterExcelData.Tribe;
        Origin = characterExcelData.Origin;
        Tier = characterExcelData.Tier;

        Image = Resources.Load<Sprite>(characterExcelData.ImagePath);
        RuntimeAnimatorController = Resources.Load<RuntimeAnimatorController>(characterExcelData.RuntimeAnimatorControllerPath);
        OriginData = GameManager.instance.dataSheet.originDataSheet.OriginDatas[Origin];
        TribeData = GameManager.instance.dataSheet.tribeDataSheet.TribeDatas[Tribe];
    }

    public int Id;
    public string Name;
    public Tribe Tribe;
    public Origin Origin;
    public Tier Tier;
    public Sprite Image;
    public RuntimeAnimatorController RuntimeAnimatorController;
    public OriginData OriginData;
    public TribeData TribeData;
}
