using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsService : MonoBehaviour
{
    public static readonly List<int> RUNE_SALES_ID_LIST = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
    public static readonly List<Tuple<int, RuneRating>> RANDOM_RUNE_SALES_ID_AND_RATING_LIST =
        new List<Tuple<int, RuneRating>> { 
            new Tuple<int, RuneRating>(10, RuneRating.Normal),
            new Tuple<int, RuneRating>(11, RuneRating.Normal),
            new Tuple<int, RuneRating>(12, RuneRating.Unique),
            new Tuple<int, RuneRating>(13, RuneRating.Unique)
        };

    public const int FIRST_GOLD_SALES_ID = 1;
    public const int SECOND_GOLD_SALES_ID = 2;
    public const int THIRD_GOLD_SALES_ID = 3;

    public const int MIN_NUMBER_OF_RANDOM_RUNES = 1;

    public const string GOLD_IMAGE_PATH = "Images/Main/Coin";
    public const string DIAMOND_IMAGE_PATH = "Images/Main/Diamond";

    public static Sprite GOLD_IMAGE = Resources.Load<Sprite>(GOLD_IMAGE_PATH);
    public static Sprite DIAMOND_IMAGE = Resources.Load<Sprite>(DIAMOND_IMAGE_PATH);
}
