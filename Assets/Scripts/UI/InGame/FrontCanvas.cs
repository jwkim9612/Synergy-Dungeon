using UnityEngine;

public class FrontCanvas : MonoBehaviour
{
    public UIScenarioEvent uiScenarioEvent;
    public UIEventOccurred uiEventOccurred;

    public void Initialize()
    {
        uiScenarioEvent.Initialize();
    }
}
