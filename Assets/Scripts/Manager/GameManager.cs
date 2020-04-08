using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //매니저들
    public static GameManager instance = null;
    public UIManager uiManager = null;
    public SoundManager soundManager = null;

    public GameData gameData = null;

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

        // 다른 씬으로 이동해도 소멸되지 않음
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        uiManager.Initialize();
        soundManager.Initialize();
    }

    public void Quit()
    {
        // 에디터인 경우 play모드를 false로
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // 어플리케이션 종료
        #else
            Application.Quit();
        #endif

    }
}
