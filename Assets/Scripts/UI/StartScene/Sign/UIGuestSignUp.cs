using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGuestSignUp : MonoBehaviour
{
    [SerializeField] private InputField idInputField;
    [SerializeField] private InputField pwInputField;
    [SerializeField] private InputField displayNameInputField;
    [SerializeField] private UIGuestSign uiGuestSign;

    public void OnClick_SignUp()
    {
        string id = idInputField.text;
        string pw = pwInputField.text;

        Debug.Log(id);
        Debug.Log(pw);
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayNameInputField.text) // DisplayName 이 닉네임일듯
            .SetUserName(idInputField.text) // 계정아이디
            .SetPassword(pwInputField.text) // 비밀번호
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    GameManager.instance.accountManager.Sign(id, pw);
                    Debug.Log("회원가입 완료");
                }
                else
                {

                    Debug.Log("회원가입 실패" + response.Errors.JSON.ToString());
                }
            }
        );
    }


}
