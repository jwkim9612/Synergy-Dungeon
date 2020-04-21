using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedService
{
    public class RandomService
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
}
