using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{
    [SerializeField] private Button showMoneyButton = null;

    // Start is called before the first frame update
    void Start()
    {
        showMoneyButton.onClick.AddListener(() => {
            Debug.Log(GameManager.instance.gameData.coin);

        });
    }
}
