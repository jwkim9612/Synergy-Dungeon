using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignMain : MonoBehaviour
{
    [SerializeField] private Button guestSignButton;
    [SerializeField] private Button googleSignButton;

    [SerializeField] private GameObject guestSign;

    private void Start()
    {
        guestSignButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            guestSign.SetActive(true);
        });
    }

}
