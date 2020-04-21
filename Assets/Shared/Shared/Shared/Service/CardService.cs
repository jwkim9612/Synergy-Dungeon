﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SharedService
{ 
    public class CardService
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
