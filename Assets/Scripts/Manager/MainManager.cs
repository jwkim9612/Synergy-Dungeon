using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    public UIAskGoToStore uiAskGoToStore = null;
    public UIIllustratedBook uiIllustratedBook = null;
    public UIStore uiStore = null;
    [SerializeField] private GameObject connecting = null;

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
    }

    public void ShowConnecting()
    {
        connecting.SetActive(true);
    }

    public void HideConnecting()
    {
        connecting.SetActive(false);

    }
}
