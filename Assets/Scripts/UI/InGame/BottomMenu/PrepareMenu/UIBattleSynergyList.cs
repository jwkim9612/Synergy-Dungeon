using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleSynergyList : MonoBehaviour
{
    [SerializeField] private UIInGameSynergyInfo uiInGameSynergyInfo = null;
    [SerializeField] private ToggleGroup toggleGroup = null;
    private List<UITribe> uiTribes;
    private List<UIOrigin> uiOrigins;
    private SynergySystem synergySystem;

    private Camera cam;


    private void Start()
    {
        InitializeTribeList();
        InitializeOriginList();

        synergySystem = InGameManager.instance.synergySystem;
        synergySystem.OnTribeChanged += UpdateTribes;
        synergySystem.OnOriginChanged += UpdateOrigins;
        synergySystem.OnTribeChanged += UpdateSynergyListSize;
        synergySystem.OnOriginChanged += UpdateSynergyListSize;

        if (SaveManager.Instance.IsLoadedData)
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.CharacterAreaInfoList);
        }

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!TransformService.ContainPos(transform as RectTransform, Input.mousePosition, cam))
            {
                if(uiInGameSynergyInfo.gameObject.activeSelf)
                {
                    uiInGameSynergyInfo.OnHide();
                }
            }
        }
    }

    private void InitializeTribeList()
    {
        uiTribes = new List<UITribe>();

        var tribes = this.GetComponentsInChildren<UITribe>();
        foreach (var tribe in tribes)
        {
            uiTribes.Add(tribe);
            tribe.uiInGameSynergyInfo = this.uiInGameSynergyInfo;
            tribe.gameObject.SetActive(false);
        }
    }

    private void InitializeOriginList()
    {
        uiOrigins = new List<UIOrigin>();

        var origins = this.GetComponentsInChildren<UIOrigin>();
        foreach (var origin in origins)
        {
            uiOrigins.Add(origin);
            origin.uiInGameSynergyInfo = this.uiInGameSynergyInfo;
            origin.gameObject.SetActive(false);
        }
    }

    public void UpdateTribes()
    {
        int tribeIndex = 0;

        var tribes = synergySystem.appliedTribes;
        foreach(var tribe in tribes)
        {
            var tribeDataSheet = DataBase.Instance.tribeDataSheet;
            if (tribeDataSheet == null)
            {
                Debug.LogError("Error tribeDataSheet is null");
                return;
            }

            if (tribeDataSheet.TryGetTribeData(tribe.Key, out var tribeData))
            {
                uiTribes[tribeIndex].SetImage(tribeData.Image);
                uiTribes[tribeIndex].SetTribe(tribeData.Tribe);
            }

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
            var originDataSheet = DataBase.Instance.originDataSheet;
            if(originDataSheet == null)
            {
                Debug.LogError("Error originDataSheet is null");
                return;
            }

            if(originDataSheet.TryGetOriginData(origin.Key, out var originData))
            {

                uiOrigins[originIndex].SetImage(originData.Image);
                uiOrigins[originIndex].SetOrigin(originData.Origin);
            }

            uiOrigins[originIndex].gameObject.SetActive(true);
            ++originIndex;
        }

        for (int i = originIndex; i < uiOrigins.Count; ++i)
        {
            uiOrigins[i].gameObject.SetActive(false);
        }
    }

    private void UpdateSynergyListSize()
    {
        int count = 0;

        foreach (Transform child in transform)
        {
            if(child.gameObject.activeSelf)
            {
                ++count;
            }
        }

        RectTransform rect = transform as RectTransform;

        float sum = 0.03f + (0.073f * count);

        rect.anchorMax = new Vector2(sum, 1.0f);

        var position = rect.anchoredPosition;
        position.x = 0.0f;

        rect.anchoredPosition = position;
    }

    private void InitializeByInGameSaveData(List<CharacterInfo> characterInfoList)
    {
        foreach(var characterInfo in characterInfoList)
        {
            if (characterInfo == null)
            {
                continue;
            }

            synergySystem.AddCharacter(characterInfo);
        }
    }
}
