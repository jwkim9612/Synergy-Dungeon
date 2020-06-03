using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsService : MonoBehaviour
{
    public const int FIRST_GOLD_SALES_ID = 1;
    public const int SECOND_GOLD_SALES_ID = 2;
    public const int THIRD_GOLD_SALES_ID = 3;
    public const int FIRST_RUNE_SALES_ID = 4;
    public const int SECOND_RUNE_SALES_ID = 5;

    public const int MIN_NUMBER_OF_RANDOM_RUNES = 1;

    public const string GOLD_IMAGE_PATH = "Images/Main/Coin";
    public const string DIAMOND_IMAGE_PATH = "Images/Main/Diamond";

    public static Sprite GOLD_IMAGE = Resources.Load<Sprite>(GOLD_IMAGE_PATH);
    public static Sprite DIAMOND_IMAGE = Resources.Load<Sprite>(DIAMOND_IMAGE_PATH);
}
