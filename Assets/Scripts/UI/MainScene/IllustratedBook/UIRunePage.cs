using GameSparks.Api.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRunePage : MonoBehaviour
{
    [SerializeField] private UIOwnedRunes uiOwnedRunes = null;
    [SerializeField] private UIEquippedRunes uiEquippedRunes = null;
    [SerializeField] private Button button1 = null;
    [SerializeField] private Button button2 = null;
    [SerializeField] private Button button3 = null;


    private void Start()
    {
        uiOwnedRunes.Initialize();
        uiEquippedRunes.Initialize();

        button1.onClick.AddListener(() =>
        {
            uiOwnedRunes.AddUIRune(2001);
        });

        button2.onClick.AddListener(() =>
        {
            uiOwnedRunes.AddUIRune(1000);
        });

        button3.onClick.AddListener(() =>
        {
            BuyTest(1);
        });
    }

    private void BuyTest(int id)
    {
        new LogEventRequest()
           .SetEventKey("BuyingGoods")
           .SetEventAttribute("ItemId", id)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   int price = (int)(response.ScriptData.GetInt("Price"));


                   Debug.Log("price = " + price);
               }
               else
               {
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }
}
