using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    void Start()
    {

    }

    // 화면에 표시
    public void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    // 화면에서 숨김
    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }
}
