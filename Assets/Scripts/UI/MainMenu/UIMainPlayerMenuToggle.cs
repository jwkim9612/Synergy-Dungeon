using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainPlayerMenuToggle : MonoBehaviour
{
    public GameObject clickedImage;
    public GameObject unclickedImage;
    
    public void OnChangeValue()
    {
        bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if(onoffSwitch)
        {
            clickedImage.SetActive(true);
            unclickedImage.SetActive(false);
        }
        else
        {
            clickedImage.SetActive(false);
            unclickedImage.SetActive(true);
        }

    }

    void Start()
    {
        
    }
}
