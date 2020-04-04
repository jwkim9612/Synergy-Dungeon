using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button btn_start;
    [SerializeField] private Button btn_option;
    [SerializeField] private Button btn_exit;

    void Start()
    {
        
    }

    public void OnClickStartButton()
    {
        Debug.Log("Start");
    }

    public void OnClickOptionButton()
    {
        Debug.Log("Option");
    }

    public void OnClickQuitButton()
    {
        Debug.Log("End");
    }
}
