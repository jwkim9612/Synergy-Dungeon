using GameSparks.Api.Requests;
using GameSparks.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoSingleton<GoodsManager>
{
    private int rewardAmount;
    private int rewardId;
    private List<RuneGrade> randomlyPickedRuneGradeList;
    public List<(int RuneId, bool IsSoldOut)> runeOnSalesList { get; set; }  

    public void Initialize()
    {
        LoadRuneOnSalesData();
        //ResetRuneOnSales();
    }


    public void PurchaseGoods(int goodsId)
    {
        MainManager.instance.uiStore.ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseGoods")
           .SetEventAttribute("GoodsId", goodsId)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if (result)
                   {
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));

                       string strRewardCurrency = (response.ScriptData.GetString("RewardCurrency"));
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

                       MainManager.instance.uiStore.HideBeginPurchase();
                       MainManager.instance.uiAskGoToStore.SetText(purchaseCurrency);
                       UIManager.Instance.ShowNew(MainManager.instance.uiAskGoToStore); // 다이아, 골드 구매 창으로 이동할지 물어보는 팝업창 띄우기
                   }
               }
               else
               {
                   MainManager.instance.uiStore.HideBeginPurchase();
                   // 서버 문제로 구매 실패 팝업 띄우기.
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void PurchaseRune(int goodsId, int runeOnSalesId, RuneGrade runeGrade)
    {
        MainManager.instance.uiStore.ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseRune")
           .SetEventAttribute("GoodsId", goodsId)
           .SetEventAttribute("RuneOnSalesId", runeOnSalesId)
           .SetEventAttribute("RuneOnSalesGrade", runeGrade.ToString())
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool isBuyable = (bool)(response.ScriptData.GetBoolean("IsBuyable"));
                   if (isBuyable)
                   {
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));

                       string strRewardCurrency = (response.ScriptData.GetString("RewardCurrency"));
                       RewardCurrency rewardCurrency = (RewardCurrency)Enum.Parse(typeof(RewardCurrency), strRewardCurrency);

                       rewardId = (int)(response.ScriptData.GetInt("RewardId"));

                       MainManager.instance.uiStore.uiRuneOnSalesList.SetIsSoldOutToId(runeOnSalesId);
                       StartCoroutine(Co_GetItems(rewardCurrency));
                   }
                   else
                   {
                       bool isSoldOut = (bool)(response.ScriptData.GetBoolean("IsSoldOut"));
                       MainManager.instance.uiStore.HideBeginPurchase();
                       if (isSoldOut)
                       {
                           Debug.Log("Error is sold out!!!");
                       }
                       else
                       {
                           string strPurchaseCurrency = (response.ScriptData.GetString("PurchaseCurrency"));
                           PurchaseCurrency purchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), strPurchaseCurrency);

                           MainManager.instance.uiAskGoToStore.SetText(purchaseCurrency);
                           UIManager.Instance.ShowNew(MainManager.instance.uiAskGoToStore); // 다이아, 골드 구매 창으로 이동할지 물어보는 팝업창 띄우기
                       }
                   }
               }
               else
               {
                   MainManager.instance.uiStore.HideBeginPurchase();
                   // 서버 문제로 구매 실패 팝업 띄우기.
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void PurchaseRandomRune(int goodsId, RuneRating runeRating)
    {
        MainManager.instance.uiStore.ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseRandomRune")
           .SetEventAttribute("GoodsId", goodsId)
           .SetEventAttribute("RatingOfRandomRune", runeRating.ToString())
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if (result)
                   {
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));

                       string strRewardCurrency = (response.ScriptData.GetString("RewardCurrency"));
                       RewardCurrency rewardCurrency = (RewardCurrency)Enum.Parse(typeof(RewardCurrency), strRewardCurrency);

                       var strGradeList = response.ScriptData.GetStringList("RuneGradeList");

                       foreach(var a in strGradeList)
                       {
                           Debug.Log(a);
                       }

                       SetRandomlyPickedRuneGradeList(strGradeList);
                       StartCoroutine(Co_GetItems(rewardCurrency));
                   }
                   else
                   {
                       string strPurchaseCurrency = (response.ScriptData.GetString("PurchaseCurrency"));
                       PurchaseCurrency purchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), strPurchaseCurrency);

                       MainManager.instance.uiStore.HideBeginPurchase();
                       MainManager.instance.uiAskGoToStore.SetText(purchaseCurrency);
                       UIManager.Instance.ShowNew(MainManager.instance.uiAskGoToStore); // 다이아, 골드 구매 창으로 이동할지 물어보는 팝업창 띄우기
                   }
               }
               else
               {
                   MainManager.instance.uiStore.HideBeginPurchase();
                   // 서버 문제로 구매 실패 팝업 띄우기.
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void PurchaseRandomPotion(int goodsId)
    {
        MainManager.instance.uiStore.ShowBeingPurchase(); // 구매중 팝업 띄우기.

        new LogEventRequest()
           .SetEventKey("PurchaseRandomPotion")
           .SetEventAttribute("GoodsId", goodsId)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                   if (result)
                   {
                       rewardAmount = (int)(response.ScriptData.GetInt("RewardAmount"));

                       string strRewardCurrency = (response.ScriptData.GetString("RewardCurrency"));
                       RewardCurrency rewardCurrency = (RewardCurrency)Enum.Parse(typeof(RewardCurrency), strRewardCurrency);

                       StartCoroutine(Co_GetItems(rewardCurrency));
                   }
                   else
                   {
                       string strPurchaseCurrency = (response.ScriptData.GetString("PurchaseCurrency"));
                       PurchaseCurrency purchaseCurrency = (PurchaseCurrency)Enum.Parse(typeof(PurchaseCurrency), strPurchaseCurrency);

                       MainManager.instance.uiStore.HideBeginPurchase();
                       MainManager.instance.uiAskGoToStore.SetText(purchaseCurrency);
                       UIManager.Instance.ShowNew(MainManager.instance.uiAskGoToStore); // 다이아, 골드 구매 창으로 이동할지 물어보는 팝업창 띄우기
                   }
               }
               else
               {
                   MainManager.instance.uiStore.HideBeginPurchase();
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

        MainManager.instance.uiStore.HideBeginPurchase(); // 구매중 팝업 없애기.
        MainManager.instance.uiStore.PlayPurchaseCompletedFloatingText(); // 구매 완료! 띄우기


        switch (rewardCurrency)
        {
            case RewardCurrency.Gold:
                //PlayerDataManager.Instance.LoadPlayerData();
                break;
            case RewardCurrency.Rune:
                RuneManager.Instance.AddRuneToRuneList(rewardId);
                break;
            case RewardCurrency.RandomRune:
                AddRunesAndShowObtainedRunes();
                break;
            case RewardCurrency.RandomPotion:
                Debug.Log("랜덤 포션 구입 완료!!");
                break;
            case RewardCurrency.Heart:
                MainManager.instance.uiTopMenu.uiHeart.HeartUpdate();
                break;
        }
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
            MainManager.instance.uiStore.uiObtainedRuneScreen.SetUIObtainedRune(obtainedRandomIds[0]);
            UIManager.Instance.ShowNew(MainManager.instance.uiStore.uiObtainedRuneScreen);
        }
        else
        {
            MainManager.instance.uiStore.uiObtainedRunesScreen.SetUIObtainedRuneList(obtainedRandomIds);
            UIManager.Instance.ShowNew(MainManager.instance.uiStore.uiObtainedRunesScreen);
        }
    }

    private void InitializeRuneOnSalesData(List<int> runeIdList, bool isResetOnMainMenu = false)
    {
        //List<int> amount = new List<int>();
        //for(int i = 0; i < aa.Count; ++i)
        //{
        //    amount.Add(DataBase.Instance.runeDataSheet.RuneDatas[aa[i]].Id);
        //}

        new LogEventRequest()
           .SetEventKey("InitializeRuneOnSalesData")
           .SetEventAttribute("RuneOnSalesIds", runeIdList)
           //.SetEventAttribute("RuneOnSalesAmounts", amount)
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   if(isResetOnMainMenu)
                   {
                       LoadRuneOnSalesDataAndInitializeUIRuneOnSalesList();
                   }
                   else
                   {
                       LoadRuneOnSalesData();
                   }
               }
               else
               {
                   Debug.Log("Error InitializeRuneOnSales");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void LoadRuneOnSalesData()
    {
        new LogEventRequest()
           .SetEventKey("LoadRuneOnSalesData")
           .Send((response) =>
           {
           if (!response.HasErrors)
           {
               bool result = (bool)(response.ScriptData.GetBoolean("Result"));
               if (result)
               {
                   GSData runeOnSalesScriptDataList = response.ScriptData.GetGSData("RuneOnSalesData");
                   JObject runeOnSalesListJsonObject = JsonDataManager.Instance.LoadJson<JObject>(runeOnSalesScriptDataList.JSON);

                       runeOnSalesList = new List<(int RuneId, bool IsSoldOut)>();

                       foreach (var runeOnSalesListPair in runeOnSalesListJsonObject)
                       {
                           JObject runeOnSalesJsonObject = JsonDataManager.Instance.LoadJson<JObject>(runeOnSalesListPair.Value.ToString());

                           int index = 0; int idIndex = 0; int isSoldOutIndex = 1;
                           int id = 0;
                           bool isSoldOut = false;
                           foreach (var runeOnSalesPair in runeOnSalesJsonObject)
                           {
                               if (index == idIndex)
                                   id = int.Parse(runeOnSalesPair.Value.ToString());
                               else if (index == isSoldOutIndex)
                                   isSoldOut = (bool)(runeOnSalesPair.Value);

                               ++index;
                           }
                           runeOnSalesList.Add((id, isSoldOut));
                       }
                   }
                   else
                   {
                       ResetRuneOnSales();
                   }
               }
               else
               {
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void LoadRuneOnSalesDataAndInitializeUIRuneOnSalesList()
    {
        new LogEventRequest()
           .SetEventKey("LoadRuneOnSalesData")
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   GSData runeOnSalesScriptDataList = response.ScriptData.GetGSData("RuneOnSalesData");
                   JObject runeOnSalesListJsonObject = JsonDataManager.Instance.LoadJson<JObject>(runeOnSalesScriptDataList.JSON);

                   runeOnSalesList = new List<(int RuneId, bool IsSoldOut)>();

                   foreach (var runeOnSalesListPair in runeOnSalesListJsonObject)
                   {
                       JObject runeOnSalesJsonObject = JsonDataManager.Instance.LoadJson<JObject>(runeOnSalesListPair.Value.ToString());

                       int index = 0; int idIndex = 0; int isSoldOutIndex = 1;
                       int id = 0;
                       bool isSoldOut = false;
                       foreach (var runeOnSalesPair in runeOnSalesJsonObject)
                       {
                           if (index == idIndex)
                               id = int.Parse(runeOnSalesPair.Value.ToString());
                           else if (index == isSoldOutIndex)
                               isSoldOut = (bool)(runeOnSalesPair.Value);

                           ++index;
                       }
                       runeOnSalesList.Add((id, isSoldOut));
                   }

                   MainManager.instance.uiStore.uiRuneOnSalesList.Initialize();
                   Debug.Log("runeslaes 초기화 완료");
               }
               else
               {
                   Debug.Log("Error BuyTest");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }

    public void ResetRuneOnSales(bool isResetOnMainMenu = false)
    {
        new LogEventRequest()
           .SetEventKey("GetRuneOnSalesGradeList")
           .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   List<string> runeOnSalesGradeListStr = response.ScriptData.GetStringList("RuneOnSalesGradeList");
                   List<RuneGrade> runeOnSalesGradeList = RuneService.stringGradeListToRuneGradeList(runeOnSalesGradeListStr);
                   List<int> runeIdList = RuneService.GetRandomIdListByRuneGradeList(runeOnSalesGradeList);
                   
                   if(isResetOnMainMenu)
                   {
                       InitializeRuneOnSalesData(runeIdList, true);
                   }
                   else
                   {
                       InitializeRuneOnSalesData(runeIdList, false);
                   }
               }
               else
               {
                   Debug.Log("Error InitializeRuneOnSales");
                   Debug.Log(response.Errors.JSON);
               }
           });
    }
}
