using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScenarioEventButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text text;

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetButton(Action callback)
    {
        button.onClick.AddListener(() =>
        {
            callback();
        });
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
