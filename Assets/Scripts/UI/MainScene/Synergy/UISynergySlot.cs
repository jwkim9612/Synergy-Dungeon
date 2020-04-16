using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UISynergySlot : MonoBehaviour
{
    [SerializeField] private UISynergyInfo synergyInfo = null;
    [SerializeField] private Image synergyImage = null;
    [SerializeField] private Text synergyName = null;

    public TribeData tribeData = null;
    public OriginData originData = null;

    public void SetSynergyData(TribeData newTribeData)
    {
        originData = null;
        tribeData = newTribeData;

        Setimage(tribeData.image);
        SetName(tribeData.tribe);
    }

    public void SetSynergyData(OriginData newOriginData)
    {
        tribeData = null;
        originData = newOriginData;

        Setimage(originData.image);
        SetName(originData.origin);
    }

    public void Setimage(Sprite sprite)
    {
        if(sprite != null)
        {
            synergyImage.sprite = sprite;
        }
        else
        {
            Debug.Log("No Synergy Slot Image");
        }
    }

    public void SetName(Tribe tribe)
    {
        switch (tribe)
        {
            case Tribe.Human:
                synergyName.text = "휴먼";
                break;
            case Tribe.Elf:
                synergyName.text = "엘프";
                break;
            case Tribe.Devil:
                synergyName.text = "악마";
                break;
            case Tribe.Undead:
                synergyName.text = "언데드";
                break;
            case Tribe.Elemental:
                synergyName.text = "정령";
                break;
            case Tribe.Machine:
                synergyName.text = "기계";
                break;
            case Tribe.Beast:
                synergyName.text = "야수";
                break;
        }
    }

    public void SetName(Origin origin)
    {
        switch (origin)
        {
            case Origin.Warrior:
                synergyName.text = "전사";
                break;
            case Origin.Knight:
                synergyName.text = "기사";
                break;
            case Origin.Archer:
                synergyName.text = "궁수";
                break; 
            case Origin.Thief:
                synergyName.text = "도적";
                break;
            case Origin.Priest:
                synergyName.text = "프리스트";
                break;
            case Origin.Dragon:
                synergyName.text = "드래곤";
                break;
        }
    }

    public void OnClicked()
    {
        if(tribeData != null)
        {
            synergyInfo.SetSynergyData(tribeData, synergyName.text, tribeData.description, tribeData.image);
        }
        else if(originData != null)
        {
            synergyInfo.SetSynergyData(originData, synergyName.text, originData.description, originData.image);
        }
        else
        {
            Debug.Log("No SynergyData");
        }

        GameManager.instance.uiManager.ShowNew(synergyInfo);
    }
}
