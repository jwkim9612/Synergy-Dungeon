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
            GoodsManager.Instance.BuyingGoods(1);
        });

        BuyItem2.onClick.AddListener(() =>
        {
            GoodsManager.Instance.BuyingGoods(2);
        });

        BuyItem3.onClick.AddListener(() =>
        {
            GoodsManager.Instance.BuyingGoods(3);
        });
    }


}
