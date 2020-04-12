using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // 화면에 표시
    public virtual void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    // 화면에서 숨김
    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }
}
