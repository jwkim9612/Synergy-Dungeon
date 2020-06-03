using GameSparks.Api.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoodsManager : MonoSingleton<GoodsManager>
{
    [SerializeField] private GameObject beingBuy;
    [SerializeField] private UIAskGoToStore uiAskGoToStore;
    [SerializeField] private UIFloatingText buyCompletedFloatingText;
    public UIStore uiStore;

    private int rewardAmount;
    private int rewardId;
    private List<RuneGrade> randomlyPickedRuneGradeList;

    private void Start()
    {
        buyCompletedFloatingText.Initialize();
    }

    public void BuyingGoods(int id)
    {
        ShowBeingBuy(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("BuyingGoods")
           .SetEventAttribute("ItemId", id)
           .Send((response) =>
           {
               HideBeginBuy(); // 구매중 팝업 없애기.

               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if (result)
                   {
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));

                       string strRewardCurrency = (response.ScriptData.GetString("RewardCurrencyType"));
                       RewardCurrency rewardCurrency = (RewardCurrency)Enum.Parse(typeof(RewardCurrency), strRewardCurrency);

                       switch (rewardCurrency)
                       {
                           case RewardCurrency.Rune:
                               rewardId = (int)(response.ScriptData.GetInt("RewardId"));
                               break;
                           case RewardCurrency.RandomRune:
                               var strGradeList = response.ScriptData.GetStringList("RuneGradeList");
                               SetRandomlyPickedRuneGradeList(strGradeList);
                               break;
                                

                       }

                       GetItems(rewardCurrency);
                       buyCompletedFloatingText.Play(); // 구매 완료! 띄우기
                   }
                   else
                   {
                       string strPurchaseCurrency = (response.ScriptData.GetString("PurchaseCurrency"));
                       PurchaseCurrency purchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), strPurchaseCurrency);


                       uiAskGoToStore.SetText(purchaseCurrency);
                       UIManager.Instance.ShowNew(uiAskGoToStore); // 다이아, 골드 구매 창으로 이동할지 물어보는 팝업창 띄우기
                   }
               }
               else
               {
                   // 서버 문제로 구매 실패 팝업 띄우기.
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    // 구매한 아이템을 플레이어 인벤토리에 넣어주는 함수
    private void GetItems(RewardCurrency rewardCurrency)
    {
        switch(rewardCurrency)
        {
            case RewardCurrency.Gold:
                PlayerDataManager.Instance.LoadPlayerData();
                break;
            case RewardCurrency.Rune:
                Debug.Log("룬 구입!!");
                RuneManager.Instance.AddRune(rewardId);
                break;
            case RewardCurrency.RandomRune:
                AddRunesAndShowObtainedRunes();
                break;
        }
    }

    private void ShowBeingBuy()
    {
        beingBuy.SetActive(true);
    }

    private void HideBeginBuy()
    {
        beingBuy.SetActive(false);
    }

    private void SetRandomlyPickedRuneGradeList(List<string> strRuneGradeList)
    {
        List<RuneGrade> runeGrades = new List<RuneGrade>();

        foreach (var strRuneGrade in strRuneGradeList)
        {
            runeGrades.Add((RuneGrade)Enum.Parse(typeof(RuneGrade), strRuneGrade));
        }

        randomlyPickedRuneGradeList = runeGrades;
    }

    private void AddRunesAndShowObtainedRunes()
    {
        List<int> obtainedRandomIds = new List<int>();

        foreach (var runeGrade in randomlyPickedRuneGradeList)
        {
            int randomId = RuneService.GetRandomIdByGrade(runeGrade);
            obtainedRandomIds.Add(randomId);
            RuneManager.Instance.AddRune(randomId);
        }

        // 뽑은 갯수에 따라 획득한 룬 화면 띄우기
        if (randomlyPickedRuneGradeList.Count == GoodsService.MIN_NUMBER_OF_RANDOM_RUNES)
        {
            uiStore.uiObtainedRuneScreen.SetUIObtainedRune(obtainedRandomIds[0]);
            UIManager.Instance.ShowNew(uiStore.uiObtainedRuneScreen);
        }
        else
        {
            uiStore.uiObtainedRunesScreen.SetUIObtainedRuneList(obtainedRandomIds);
            UIManager.Instance.ShowNew(uiStore.uiObtainedRunesScreen);
        }
    }
}
