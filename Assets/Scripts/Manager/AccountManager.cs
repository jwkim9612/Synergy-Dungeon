﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AccountManager : MonoSingleton<AccountManager>
{
    private AccountData accountData;
    [SerializeField] private AskInGameContinue askInGameContinue = null;

    [SerializeField] private UIControl signMain = null;
    [SerializeField] private UIControl uiEnterDisplayName = null;

    public void Initialize()
    {
        accountData = new AccountData();
        AccountData loadedAccoutnData = JsonDataManager.Instance.LoadJsonFile<AccountData>(Application.dataPath, "AccountData");
        if (loadedAccoutnData == null)
        {
            UIManager.Instance.ShowNew(signMain);
            // 로그인 창, 회원가입 창 띄우기

        }
        else
        {
            accountData = loadedAccoutnData;
            Sign(accountData.id, accountData.pw, false);
            // 로그인 완료.
        }
    }

    public void SaveAccountData()
    {
        Debug.Log("계정 정보 저장 완료!");
        JsonDataManager.Instance.CreateJsonFile(Application.dataPath, "AccountData", JsonDataManager.Instance.ObjectToJson(accountData));
    }

    public void SetAccountData(string id, string pw)
    {
        accountData.id = id;
        accountData.pw = pw;
        accountData.isLoginToGoogle = false;
    }

    public void Sign(string id, string pw, bool isFromSignUp)
    {
        if(id == "")
        {
            Debug.Log("No ID");
            return;
        }

        if (pw == "")
        {
            Debug.Log("No Password");
            return;
        }

        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(id)
            .SetPassword(pw)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    SetAccountData(id, pw);
                    SaveAccountData();
                    //HideAccountWindow();
                    Debug.Log("로그인 성공...");
                    if(isFromSignUp)
                    {
                        ShowEnterDisplayName();
                        // 닉네임 설정 창 오픈.
                    }
                    else
                    {
                        if (SaveManager.Instance.HasInGameData())
                            askInGameContinue.gameObject.SetActive(true);
                        else
                            SceneManager.LoadScene("MainScene");

                        //  Main Scene으로 이동
                    }
                }
                else
                {
                    Debug.Log("로그인 실패..." + response.Errors.JSON.ToString());
                    //ShowAccountWindow();
                }
            });
    }

    public void SignUp()
    {
        string id = GetRandomID();
        string pw = "1";

        Debug.Log(id);
        Debug.Log(pw);
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName("Guest") // 닉네임
            .SetUserName(id) // 계정아이디
            .SetPassword(pw) // 비밀번호
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    AccountManager.Instance.Sign(id, pw, true);
                    Debug.Log("회원가입 완료");
                }
                else
                {
                    Debug.Log("회원가입 실패" + response.Errors.JSON.ToString());
                    SignUp();
                }
            }
        );
    }

    public void ChangeDisplayName(string displayName, bool isFromSignUp)
    {
        new GameSparks.Api.Requests.ChangeUserDetailsRequest()
            .SetDisplayName(displayName)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("닉네임 변경 완료");

                    if(isFromSignUp)
                        SceneManager.LoadScene("MainScene");
                }
                else
                {
                    Debug.Log("닉네임 변경 실패");
                }
            });
    }

    

    public string GetRandomID()
    {
        Guid new_guid = Guid.NewGuid();

        string id = new_guid.GetHashCode().ToString();
        id = id.Replace('-', 'M');

        return id;
    }

    public void ShowEnterDisplayName()
    {
        uiEnterDisplayName.gameObject.SetActive(true);
    }
}