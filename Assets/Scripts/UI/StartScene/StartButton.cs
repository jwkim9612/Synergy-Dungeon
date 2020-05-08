using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnClickStartScreen()
    {
        PlayLoadingAnimation();
        LoadGameData();

        var inGameData = SaveManager.Instance.LoadInGameData();
        if(inGameData != null)
        {

            return;
        }

        SceneManager.LoadScene("MainScene");
    }

    void PlayLoadingAnimation()
    {
        // 로딩 애니메이션 시작
    }

    void LoadGameData()
    {
        // 게임 데이터 로드
    }
}
