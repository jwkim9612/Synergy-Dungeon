using UnityEngine;

public class UICharacterAndArtifact : MonoBehaviour
{
    public UIDetailedSettings uiDetailedSettings;
    public UICharacterList uiCharacterList;

    public void Initialize()
    {
        uiDetailedSettings.Initialize();
        uiCharacterList.Initialize();
    }
}
