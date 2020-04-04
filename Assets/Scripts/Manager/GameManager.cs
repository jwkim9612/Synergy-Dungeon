using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //매니저들
    public static GameManager instance = null;
    public UIManager uiManager = null;

    //파괴되지 않는 싱글턴
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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // uiManager.Initialize();
    }
}
