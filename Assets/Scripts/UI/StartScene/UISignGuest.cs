using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignGuest : MonoBehaviour
{
    [SerializeField] private InputField idInputField;
    [SerializeField] private InputField pwInputField;

    public void OnClick_GuestSign()
    {
        Debug.Log(idInputField.text.ToString());
        Debug.Log(pwInputField.text.ToString());
        new GameSparks.Api.Requests.RegistrationRequest()
            //.SetDisplayName(displayNameInput.text) // DisplayName 이 닉네임일듯
            .SetUserName(idInputField.text) // 계정아이디
            .SetPassword(pwInputField.text) // 비밀번호
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
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
