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
        SetName(tribeData.strTribe);
    }

    public void SetSynergyData(OriginData newOriginData)
    {
        tribeData = null;
        originData = newOriginData;

        Setimage(originData.image);
        SetName(originData.strOrigin);
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

    public void SetName(string name)
    {
        synergyName.text = name;
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
