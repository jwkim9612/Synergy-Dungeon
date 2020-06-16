using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] private Text connetingText;

    private void Start()
    {
        GameManager.instance.OnLoading += ShowConnectingText;
    }

    private void ShowConnectingText()
    {
        connetingText.gameObject.SetActive(true);
    }
}
