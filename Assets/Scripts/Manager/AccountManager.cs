using System;
using UnityEngine;

public class AccountManager : MonoSingleton<AccountManager>
{
    private AccountData accountData;

    [SerializeField] private GameObject signMain = null;
    [SerializeField] private UIControl uiEnterDisplayName = null;

    public void Initialize()
    {
        accountData = new AccountData();
        AccountData loadedAccoutnData = JsonDataManager.Instance.LoadJsonFile<AccountData>(Application.persistentDataPath, "AccountData");
        if (loadedAccoutnData == null)
        {
            ShowSignMain();
            // 로그인 창, 회원가입 창 띄우기

        }
        else
        {
            accountData = loadedAccoutnData;
            Sign(accountData.id, accountData.pw, false);
            PlayerDataManager.Instance.LoadPlayerData();
            // 로그인 완료.
        }
    }

    public void SaveAccountData()
    {
        Debug.Log("계정 정보 저장 완료!");
        JsonDataManager.Instance.CreateJsonFile(Application.persistentDataPath, "AccountData", JsonDataManager.Instance.ObjectToJson(accountData));
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
                    Debug.Log("로그인 성공...");
                    Debug.Log($"ID : {accountData.id}, PW : {accountData.pw}");
                    if(isFromSignUp)
                    {
                        UIManager.Instance.ShowNew(uiEnterDisplayName);
                        // 닉네임 설정 창 오픈.
                    }
                    else
                    {
                        Debug.Log("Check Start");
                        SaveManager.Instance.CheckHasInGameData();
                    }
                }
                else
                {
                    Debug.Log("로그인 실패..." + response.Errors.JSON.ToString()); 
                    ShowSignMain();
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
                    PlayerDataManager.Instance.InitializePlayerData();
                    Sign(id, pw, true);
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

    public void ChangeDisplayNameAndLoadMainScene(string displayName, bool isFromSignUp)
    {
        new GameSparks.Api.Requests.ChangeUserDetailsRequest()
            .SetDisplayName(displayName)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("닉네임 변경 완료");

                    if (isFromSignUp)
                        GameManager.instance.LoadGameAndLoadMainScene();
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

    private void ShowSignMain()
    {
        signMain.SetActive(true);
        UIManager.Instance.SetCanEscape(true);
    }
}
