using GameSparks.Api.Requests;
using GameSparks.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoodsManager : MonoSingleton<GoodsManager>
{
    [SerializeField] private GameObject beingPurchase = null;
    [SerializeField] private UIAskGoToStore uiAskGoToStore = null;
    //[SerializeField] private UIFloatingText buyCompletedFloatingText = null;
    public UIStore uiStore;

    private int rewardAmount;
    private int rewardId;
    private List<RuneGrade> randomlyPickedRuneGradeList;
    public List<Tuple<int, bool>> runeOnSalesList;

    public void Initialize()
    {
        Debug.Log("여기가 먼저되야햄");
        InitializeRuneOnSalesData();
        Debug.Log("여기가 먼저되야햄");
    }

    private void Start()
    {
        //buyCompletedFloatingText.Initialize();
    }

    public void PurchaseGoods(int id)
    {
        ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseGoods")
           .SetEventAttribute("ItemId", id)
           .Send((response) =>
           {
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

                       StartCoroutine(Co_GetItems(rewardCurrency));
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

    public void PurchaseGoods(int id, int runeOnSalesIndex, RuneGrade runeGrade)
    {
        ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseGoods")
           .SetEventAttribute("ItemId", id)
           .SetEventAttribute("RuneOnSalesIndex", runeOnSalesIndex)
           .SetEventAttribute("RuneGrade", runeGrade.ToString())
           .Send((response) =>
           {
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
                       }

                       StartCoroutine(Co_GetItems(rewardCurrency));
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
    private IEnumerator Co_GetItems(RewardCurrency rewardCurrency)
    {
        PlayerDataManager.Instance.LoadPlayerData();
        yield return new WaitForSeconds(1.0f);

        HideBeginPurchase(); // 구매중 팝업 없애기.
        //buyCompletedFloatingText.Play(); // 구매 완료! 띄우기


        switch (rewardCurrency)
        {
            case RewardCurrency.Gold:
                //PlayerDataManager.Instance.LoadPlayerData();
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

    private void ShowBeingPurchase()
    {
        beingPurchase.SetActive(true);
    }

    private void HideBeginPurchase()
    {
        beingPurchase.SetActive(false);
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

    private void InitializeRuneOnSalesData()
    {
        List<int> aa = new List<int>();
        aa.Add(1001);
        aa.Add(2001);
        aa.Add(3001);
        aa.Add(4001);
        aa.Add(1002);
        aa.Add(1003);
        aa.Add(1004);
        aa.Add(1005);

        List<int> amount = new List<int>();
        for(int i = 0; i < aa.Count; ++i)
        {
            amount.Add(GameManager.instance.dataSheet.runeDataSheet.RuneDatas[aa[i]].Id);
        }

        new LogEventRequest()
           .SetEventKey("InitializeRuneOnSalesData")
           .SetEventAttribute("RuneOnSalesIds", aa)
           .SetEventAttribute("RuneOnSalesAmounts", amount)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   Debug.Log("Success InitializeRuneOnSales");
                   LoadRuneOnSalesData();
               }
               else
               {
                   Debug.Log("Error InitializeRuneOnSales");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    private void LoadRuneOnSalesData()
    {
        new LogEventRequest()
           .SetEventKey("LoadRuneOnSalesData")
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   List<GSData> runeOnSalesScriptDataList = response.ScriptData.GetGSDataList("RuneOnSalesData");

                   runeOnSalesList = new List<Tuple<int, bool>>();

                   foreach(var runeOnSalesScriptData in runeOnSalesScriptDataList)
                   {
                       JObject runeOnSalesJsonObject = JsonDataManager.Instance.LoadJson<JObject>(runeOnSalesScriptData.JSON);
                       foreach(var runeOnSalesPair in runeOnSalesJsonObject)
                       {
                           runeOnSalesList.Add(new Tuple<int, bool>(int.Parse(runeOnSalesPair.Key), (bool)(runeOnSalesPair.Value)));
                       }
                   }

                   Debug.Log("runeslaes 초기화 완료");
               }
               else
               {
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }
}
