using UnityEngine;

public class FrontCanvas : MonoBehaviour
{
    public UIAskGoToStore uiAskGoToStore;
    public AskInGameContinue askInGameContinue;
    
    [SerializeField] private GameObject connecting = null;
    [SerializeField] private GameObject EnteringDungeon = null;

    public void Initialize()
    {
        uiAskGoToStore.Initialize();
        askInGameContinue.Initialize();
    }

    public void ShowAskInGameContinue()
    {
        askInGameContinue.gameObject.SetActive(true);
    }

    public void ShowConnecting()
    {
        connecting.SetActive(true);
    }

    public void HideConnecting()
    {
        connecting.SetActive(false);
    }

    public void ShowEnteringDungeon()
    {
        EnteringDungeon.SetActive(true);
    }

    public void HideEnteringDungeon()
    {
        EnteringDungeon.SetActive(false);
    }
}
