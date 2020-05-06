using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Service
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

        public static int RandRange(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
