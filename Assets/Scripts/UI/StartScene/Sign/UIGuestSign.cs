using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UIGuestSign : MonoBehaviour
{
    [SerializeField] private InputField idInputField;
    [SerializeField] private InputField pwInputField;
    [SerializeField] private GameObject uiGuestSignUp;

    // 계정이름과 비밀번호로 로그인
    public void OnClick_Sign()
    {
        string id = idInputField.text;
        string pw = pwInputField.text;

        GameManager.instance.accountManager.Sign(id, pw);
    }

    public void OnClick_SignUp()
    {
        this.gameObject.SetActive(false);
        uiGuestSignUp.SetActive(true);
    }
}
