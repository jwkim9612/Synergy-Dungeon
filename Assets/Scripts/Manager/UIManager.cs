using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIControl exitUIControl = null;

    private bool isInitialized = false;
    
    //UI 기록
    private Stack<UIControl> uiHistory = new Stack<UIControl>();

    void Awake()
    {
        //매니저 등록
        GameManager.instance.uiManager = this;
    }

    public void Initialize()
    {
        isInitialized = true;
    }

    void Start()
    {
        if(isInitialized)
        {
            return;
        }

        isInitialized = true;
        Initialize();
    }

    public void ShowMessage(string _message)
    {
        //messageUI.ShowMessage(_message);
    }

    public void test(string _message)
    {
        Debug.Log("Test");
    }

    void Update()
    {
        //Back키 입력 시 뒤로 가기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideAndShowPreview();
        }
    }

    //새로운 UIControl 추가 및 표시
    public void ShowNew(UIControl newUI)
    {
        newUI.OnShow();
        uiHistory.Push(newUI);
    }

    public void AddHistroy(UIControl newUI)
    {
        uiHistory.Push(newUI);
    }

    public void DeleteHistory()
    {
        uiHistory.Pop();
    }

    //이전 UIControl 숨김 후 새로운 UIControl 추가 및 표시
    public void HidePreviewAndShowNew(UIControl newUI)
    {
        if (uiHistory.Count != 0)
        {
            uiHistory.Peek().OnHide();
        }
        newUI.OnShow();
        uiHistory.Push(newUI);
    }

    //현재 UIControl 숨김 후 이전 UIControl 표시
    public void HideAndShowPreview()
    {
        if (uiHistory.Count != 0)
        {
            uiHistory.Pop().OnHide();

            if (uiHistory.Count != 0)
            {
                uiHistory.Peek().OnShow();
            }
        }
        else
        {
            //아무 UI도 표시 안되있을 경우 종료 UI 표시
            ShowNew(exitUIControl);
        }
    }
}
