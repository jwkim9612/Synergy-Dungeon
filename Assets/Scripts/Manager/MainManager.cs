using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance = null;

    public UIAskGoToStore uiAskGoToStore = null;
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
