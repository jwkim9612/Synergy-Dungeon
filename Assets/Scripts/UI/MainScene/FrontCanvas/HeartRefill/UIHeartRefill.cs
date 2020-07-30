using UnityEngine;

public class UIHeartRefill : UIControl
{
    public UIHeartTimer uiHeartTimer;

    public void Initialize()
    {
        uiHeartTimer.Initialize();
    }
}
