using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDataManager : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnClickStartScreen()
    {
        PlayLoadingAnimation();

        LoadGameData();
        LoadPlayerData();

        SceneManager.LoadScene("MainScene");
    }

    void PlayLoadingAnimation()
    {
        // 로딩 애니메이션 시작
    }

    void LoadPlayerData()
    {
        // 플레이어 데이터 로드
    }

    void LoadGameData()
    {
        // 게임 데이터 로드
    }
}
