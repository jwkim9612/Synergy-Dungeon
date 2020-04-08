using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private Button addMoneyButton = null;

    // Start is called before the first frame update
    void Start()
    {
        addMoneyButton.onClick.AddListener(() => {
            GameManager.instance.gameData.coin++;
            GameManager.instance.dataManager.Save(GameManager.instance.gameData);
        });
    }
}
