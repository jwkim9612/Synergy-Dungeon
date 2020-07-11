using GameSparks.Api.Requests;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    public UIAskGoToStore uiAskGoToStore = null;
    public UIIllustratedBook uiIllustratedBook = null;
    public UIStore uiStore = null;
    public UITopMenu uiTopMenu = null;
    public AskInGameContinue askInGameContinue = null;
    [SerializeField] private GameObject connecting = null;
    [SerializeField] private GameObject EnteringDungeon = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UIManager.Instance.SetCanEscape(true);

        uiIllustratedBook.Initialize();
        SaveManager.Instance.CheckHasInGameData();
    }

    public void ShowConnecting()
    {
        connecting.SetActive(true);
    }

    public void HideConnecting()
    {
        connecting.SetActive(false);
    }

    public void ShowAskInGameContinue()
    {
        askInGameContinue.gameObject.SetActive(true);
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
