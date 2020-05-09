using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class UIChooseStage : UIControl
{
    [SerializeField] private UIWorld uiWorld = null;
    [SerializeField] private SimpleScrollSnap simpleScrollSnap = null;
    [SerializeField] private GameObject content = null;
    [SerializeField] private UIWorldStage worldStage = null;
    [SerializeField] private Text stageTitle = null;
    [SerializeField] private Button entranceButton = null;
    [SerializeField] private Button backButton = null;

    void Start()
    {
        CreateStageList();

        entranceButton.onClick.AddListener(() => {
            uiWorld.selectedStage = simpleScrollSnap.CurrentPanel + 1;
            uiWorld.UpdateStageInfo();
        });

        backButton.onClick.AddListener(() => {
            simpleScrollSnap.GoToPanel(uiWorld.selectedStage - 1);
        });

        simpleScrollSnap.onPanelChanged.AddListener(() =>
        {
            stageTitle.text = GameManager.instance.dataSheet.stageDatas[simpleScrollSnap.TargetPanel].name;
        });
    }

    private void CreateStageList()
    {
        int dataIndex = 0;

        var stageDatas = GameManager.instance.dataSheet.stageDatas;
        foreach (var stageData in stageDatas)
        { 
            if(dataIndex == 0)
            {
                worldStage.SetStageData(stageData);
            }
            else
            {
                var stage = Instantiate(worldStage, content.transform);
                stage.SetStageData(stageData);
            }

            ++dataIndex;
        }
    }
}
