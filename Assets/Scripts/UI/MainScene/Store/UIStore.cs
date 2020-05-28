using GameSparks.Api.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    [SerializeField] private Button BuyItem1;
    [SerializeField] private Button BuyItem2;
    [SerializeField] private Button BuyItem3;

    private void Start()
    {
        BuyItem1.onClick.AddListener(() =>
        {
            BuyingGoods(1);
        });

        BuyItem2.onClick.AddListener(() =>
        {
            BuyingGoods(2);
        });

        BuyItem3.onClick.AddListener(() =>
        {
            BuyingGoods(3);
        });
    }

    private void BuyingGoods(int id)
    {
        new LogEventRequest()
           .SetEventKey("BuyingGoods")
           .SetEventAttribute("ItemId", id)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if(result)
                   {
                       string rewardCurrencyType = (response.ScriptData.GetString("RewardCurrencyType"));
                       int rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));
                       int rewardId = (int)(response.ScriptData.GetInt("RewardId"));

                       PurchaseCurrency pruchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), rewardCurrencyType);

                       Debug.Log("test = " + pruchaseCurrency);
                       Debug.Log("타입 = " + rewardCurrencyType);
                       Debug.Log("수량 = " + rewardAmount);
                       Debug.Log("id = " + rewardId);


                   }
                   else
                   {
                       Debug.Log("구매 실패 : 돈이 부족합니다.");
                   }
               }
               else
               {
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }
}
