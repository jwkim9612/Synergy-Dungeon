using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class ProbabilityData
    {
        public float relativePercentageByStage;
        public float oneTier;
        public float twoTier;
        public float threeTier;
        public float fourTier;
        public float fiveTier;
       
    }

    [CreateAssetMenu]
    public class ProbabilitySheet : Sheet<ProbabilityData> { }
}