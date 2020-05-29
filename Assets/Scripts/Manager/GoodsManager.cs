using GameSparks.Api.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoSingleton<GoodsManager>
{
    private int rewardAmount;
    private int rewardId;

    public void BuyingGoods(int id)
    {
        new LogEventRequest()
           .SetEventKey("BuyingGoods")
           .SetEventAttribute("ItemId", id)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if (result)
                   {
                       string rewardCurrencyType = (response.ScriptData.GetString("RewardCurrencyType"));
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));
                       rewardId = (int)(response.ScriptData.GetInt("RewardId"));

                       PurchaseCurrency pruchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), rewardCurrencyType);

                       Debug.Log("test = " + pruchaseCurrency);
                       Debug.Log("타입 = " + rewardCurrencyType);
                       Debug.Log("수량 = " + rewardAmount);
                       Debug.Log("id = " + rewardId);

                       Debug.Log("구매 완료");

                       GetItems(pruchaseCurrency);
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

    // 구매한 아이템을 플레이어 인벤토리에 넣어주는 함수
    private void GetItems(PurchaseCurrency purchaseCurremncy)
    {
        switch(purchaseCurremncy)
        {
            case PurchaseCurrency.Gold:
                PlayerDataManager.Instance.LoadPlayerData();
                break;
            case PurchaseCurrency.Rune:
                Debug.Log("룬 구입!!");
                RuneManager.Instance.AddRune(rewardId);
                break;

        }
    }
}
