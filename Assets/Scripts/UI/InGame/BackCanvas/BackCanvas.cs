using UnityEngine;

public class BackCanvas : MonoBehaviour
{
    public UIInGameMainMenu uiMainMenu;
    public UIBottomMenu uiBottomMenu;

    public void Initialize()
    {
        uiMainMenu.Initialize();
        uiBottomMenu.Initialize();
    }
}
