using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEnterDisplayName : UIControl
{
    [SerializeField] private InputField displayNameInputField = null;
    [SerializeField] private Button cancelButton = null;

    public Image aaaa;

    private void Start()
    {
        cancelButton.onClick.AddListener(() =>
        {
            string displayName;

            if (displayNameInputField.text == "")
                displayName = "Guest";
            else
                displayName = displayNameInputField.text;

            AccountManager.Instance.ChangeDisplayName(displayName, true);
        });

        // 이미지 DataPath로 불러오기
        //Sprite img11;

        //img11 = Resources.Load<Sprite>("엘프머리");

        //if (img11 == null)
        //    Debug.Log("null");
        
        //aaaa.sprite = img11;

    }

}
