using UnityEngine;

public class FrontCanvas : MonoBehaviour
{
    public UIScenarioEvent uiScenarioEvent;
    public UIEventOccurred uiEventOccurred;
    public UIPause uiPause;
    public UIStageClear uiStageClear;
    public UIGameOver uiGameOver;
    public UICanNotStart uiCanNotStart;

    public void Initialize()
    {
        uiScenarioEvent.Initialize();
        uiPause.Initialize();
        uiStageClear.Initialize();
        uiGameOver.Initialize();
    }

    public void ShowGameOver()
    {
        uiGameOver.OnShow();
    }

    public void ShowStageClear()
    {
        uiStageClear.OnHide();
    }
}
