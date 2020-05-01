using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class WaveData
    {
        public int[] count;
        public int[] monsterNum;
    }

    [CreateAssetMenu]
    public class WaveSheet : Sheet<WaveData> { }

    [Serializable]
    public class WaveRefer : ReferSheet<WaveSheet, WaveData> { }
}
