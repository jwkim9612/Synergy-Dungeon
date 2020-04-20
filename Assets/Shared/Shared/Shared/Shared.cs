using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedService
{
    public class SharedRandom
    {
        //public const int NUM_Of_FRACTION = 10000;
        public static System.Random random = new System.Random();

        public static float GetRandom()
        {
            float randomNum = (float)random.NextDouble();
            
            return randomNum;
        }

        //public static void Shuffle<T>(List<T> list)
        //{
        //    System.Random rng = new System.Random();
        //    int n = list.Count;
        //    while (n > 1)
        //    {
        //        n--;
        //        int k = rng.Next(n + 1);
        //        T value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //}
    }

    public class Card
    {
        public const int NUM_OF_CARDS = 29;
        public const int MAX_NUM_OF_CARDS_PER_CHARACTER = 9;

        public static Color GetColorByTier(Tier tier)
        {
            Color color = new Color();
            switch (tier)
            {
                case Tier.One:
                    color = Color.gray;
                    break;
                case Tier.Two:
                    color = Color.green;
                    break;
                case Tier.Three:
                    color = Color.blue;
                    break;
                case Tier.Four:
                    color = Color.red;
                    break;
                case Tier.Five:
                    color = Color.yellow;
                    break;
                default:
                    Debug.Log("Error SetCostBorder");
                    break;
            }
            return color;
        }
    }

}
