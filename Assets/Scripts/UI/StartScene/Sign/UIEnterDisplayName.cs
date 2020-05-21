using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEnterDisplayName : UIControl
{
    [SerializeField] private InputField displayNameInputField = null;
    [SerializeField] private Button cancelButton = null;

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
    }
}
