using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void OnLoadingDelegate();
    public OnLoadingDelegate OnLoading { get; set; }

    //매니저들
    public static GameManager instance = null;
    public DataSheet dataSheet = null;
    public ParticleService particleService = null;


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
        UIManager.Instance.Initialize();
        SoundManager.Instance.Initialize();
        AccountManager.Instance.Initialize();
        JsonDataManager.Instance.Initialize();
        SaveManager.Instance.Initialize();
        dataSheet.Initialize();
    }

    public void LoadGameAndLoadMainScene()
    {
        StartCoroutine(Co_LoadGameAndLoadMainScene());
    }

    private IEnumerator Co_LoadGameAndLoadMainScene()
    {
        OnLoading();
        ServiceManager.Instance.Initialize();
        PlayerDataManager.Instance.Initialize();
        TimeManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        GoodsManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        StageManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        RuneManager.Instance.Initialize();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadGameAndLoadInGameScene()
    {
        StartCoroutine(Co_LoadGameAndLoadInGameScene());
    }

    private IEnumerator Co_LoadGameAndLoadInGameScene()
    {
        OnLoading();
        UIManager.Instance.Initialize();
        SoundManager.Instance.Initialize();
        ServiceManager.Instance.Initialize();
        PlayerDataManager.Instance.Initialize();
        TimeManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        GoodsManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        StageManager.Instance.Initialize();
        yield return new WaitForSeconds(0.5f);
        RuneManager.Instance.Initialize();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("InGameScene");
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
