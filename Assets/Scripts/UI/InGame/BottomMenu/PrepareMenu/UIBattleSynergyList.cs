using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleSynergyList : MonoBehaviour
{
    private List<UITribe> uiTribes;
    private List<UIOrigin> uiOrigins;
    private SynergySystem synergySystem;

    private void Start()
    {
        uiTribes = new List<UITribe>();
        uiOrigins = new List<UIOrigin>();

        var tribes = this.GetComponentsInChildren<UITribe>();
        foreach(var tribe in tribes)
        {
            uiTribes.Add(tribe);
            tribe.gameObject.SetActive(false);
        }

        var origins = this.GetComponentsInChildren<UIOrigin>();
        foreach (var origin in origins)
        {
            uiOrigins.Add(origin);
            origin.gameObject.SetActive(false);
        }

        synergySystem = InGameManager.instance.synergySystem;
        synergySystem.OnTribeChanged += UpdateTribes;
        synergySystem.OnOriginChanged += UpdateOrigins; ;


        if (SaveManager.Instance.IsLoadedData)
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.CharacterAreaInfoList);
        }
    }

    public void UpdateTribes()
    {
        int tribeIndex = 0;

        var tribes = synergySystem.appliedTribes;
        foreach(var tribe in tribes)
        {
            uiTribes[tribeIndex].SetImage(GameManager.instance.dataSheet.tribeDataSheet.TribeDatas[tribe.Key].Image);
            uiTribes[tribeIndex].SetImage(GameManager.instance.dataSheet.tribeDataSheet.TribeDatas[tribe.Key].Image);
            uiTribes[tribeIndex].gameObject.SetActive(true);
            ++tribeIndex;
        }

        for(int i = tribeIndex; i < uiTribes.Count; ++i)
        {
            uiTribes[i].gameObject.SetActive(false);
        }
    }

    public void UpdateOrigins()
    {
        int originIndex = 0;

        var origins = synergySystem.appliedOrigins;
        foreach (var origin in origins)
        {
            uiOrigins[originIndex].SetImage(GameManager.instance.dataSheet.originDataSheet.OriginDatas[origin.Key].Image);
            uiOrigins[originIndex].gameObject.SetActive(true);
            ++originIndex;
        }

        for (int i = originIndex; i < uiOrigins.Count; ++i)
        {
            uiOrigins[i].gameObject.SetActive(false);
        }
    }

    private void InitializeByInGameSaveData(List<CharacterInfo> characterInfoList)
    {
        foreach(var characterInfo in characterInfoList)
        {
            if (characterInfo.star == 0)
            {
                continue;
            }

            synergySystem.AddCharacter(characterInfo);
        }
    }
}
