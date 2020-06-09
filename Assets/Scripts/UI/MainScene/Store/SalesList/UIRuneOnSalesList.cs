using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIRuneOnSalesList : MonoBehaviour
{
    [SerializeField] private Text remainingTimeOfResetText;
    private Dictionary<int, UIRuneGoods> uiRuneOnSalesList;
    //private List<UIRuneGoods> uiRuneOnSalesList;
    /// <summary>
    /// item1은 룬 id, item2는 팔렸는지에 대한 여부
    /// </summary>
    public List<Tuple<int, bool>> runeOnSalesList;

    public void Initialize()
    {
        InitializeRuneOnSalesList();
        InitializeRemainingTimeOfReset();
    }

    public void InitializeRuneOnSalesList()
    {
        uiRuneOnSalesList = new Dictionary<int, UIRuneGoods>();

        runeOnSalesList = GoodsManager.Instance.runeOnSalesList;
        var uiRuneGoods = GetComponentsInChildren<UIRuneGoods>().ToList();

        var runePurchaseableLevelDatas = GameManager.instance.dataSheet.runePurchaseableLevelDataSheet.RunePurchaseableLevelDatas;
        int listIndex = 0;

        for (int id = GoodsService.FIRST_RUNE_SALES_ID; id <= runePurchaseableLevelDatas.Count; ++id)
        {
            uiRuneOnSalesList.Add(id, uiRuneGoods[listIndex]);

            int goodsId = id;
            var goodsData = GameManager.instance.dataSheet.goodsDataSheet.GoodsDatas[goodsId];

            uiRuneOnSalesList[id].SetUIGoods(goodsData, goodsId, runeOnSalesList[listIndex].Item1, goodsId, runeOnSalesList[listIndex].Item2);
            ++listIndex;
        }
    }

    private void InitializeRemainingTimeOfReset()
    {
        StartCoroutine(Co_PlayRemainingTimeOfReset());
    }

    private IEnumerator Co_PlayRemainingTimeOfReset()
    {
        int hour = (int)TimeManager.Instance.remainingTimeOfAttendance / 60 / 60;
        int minute = (int)TimeManager.Instance.remainingTimeOfAttendance / 60 % 60;
        int second = (int)TimeManager.Instance.remainingTimeOfAttendance % 60;
        remainingTimeOfResetText.text = "남은시간 : " + hour + "시간 " + minute + "분";

        while (hour != 0 || minute != 0 || second != 0)
        {
            yield return new WaitForSeconds(1.0f);
            if (second == 0)
            {
                if (minute == 0)
                {
                    if (hour == 0)
                    {
                        break;
                    }

                    --hour;
                    minute = 60;
                }

                --minute;
                second = 59;
                remainingTimeOfResetText.text = "남은시간 : " + hour + "시간 " + minute + "분";
            }
            else
                --second;
        }

        MainManager.instance.ShowConnecting();
        yield return new WaitForSeconds(2.0f);
        TimeManager.Instance.AttendanceCheck(true);
        yield return new WaitForSeconds(2.0f);
        MainManager.instance.HideConnecting();
    }

    public void SetIsSoldOutToId(int id)
    {
        uiRuneOnSalesList[id].SetIsSoldOut();
    }
}
