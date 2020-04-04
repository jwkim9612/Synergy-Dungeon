using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    void Start()
    {

    }

    // 화면에 표시
    public void OnShow()
    {
        canvas.gameObject.SetActive(true);
    }

    // 화면에서 숨김
    public void OnHide()
    {
        canvas.gameObject.SetActive(false);
    }
}
