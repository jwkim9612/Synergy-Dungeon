using UnityEngine;

public class UICharacterAndArtifact : MonoBehaviour
{
    public UIDetailedSettings uiDetailedSettings;
    public UICharacterList uiCharacterList;
    public UIArtifactStatus uiArtifactStatus;

    public void Initialize()
    {
        uiDetailedSettings.Initialize();
        uiCharacterList.Initialize();
        uiArtifactStatus.Initialize();
    }
}
