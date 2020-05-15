using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

public class AccountManager : MonoBehaviour
{
    private AccountData accountData;

    [SerializeField] private GameObject uiSign = null;

    public void Initialize()
    {
        accountData = new AccountData();
        AccountData loadedAccoutnData = JsonDataManager.Instance.LoadJsonFile<AccountData>(Application.dataPath, "AccountData");
        if (loadedAccoutnData == null)
        {
            uiSign.SetActive(true);
            // 로그인 창, 회원가입 창 띄우기

        }
        else
        {
            accountData = loadedAccoutnData;
            Sign(accountData.id, accountData.pw);
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

    public void Sign(string id, string pw)
    {
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(id)
            .SetPassword(pw)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    GameManager.instance.accountManager.SetAccountData(id, pw);
                    GameManager.instance.accountManager.SaveAccountData();
                    HideAccountWindow();
                    Debug.Log("로그인 성공...");
                }
                else
                {
                    Debug.Log("로그인 실패..." + response.Errors.JSON.ToString());
                    ShowAccountWindow();
                }
            });
    }

    public void ShowAccountWindow()
    {
        uiSign.SetActive(true);
    }

    public void HideAccountWindow()
    {
        uiSign.SetActive(false);
    }
}
