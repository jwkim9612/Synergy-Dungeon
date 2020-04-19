using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedService
{
    public class SharedRandom
    {
        public const int NUM_Of_FRACTION = 10000;

        public static float GetRandom()
        {
            Random random = new Random();
            float randomNum = (random.Next(0, NUM_Of_FRACTION)) / (float)NUM_Of_FRACTION;

            return randomNum;
        }

        public static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Card
    {
        public const int NUM_OF_CARDS = 29;
        public const int MAX_NUM_OF_CARDS_PER_CHARACTER = 9;
    }

}
