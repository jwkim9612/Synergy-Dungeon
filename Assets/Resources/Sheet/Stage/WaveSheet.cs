using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class WaveData
    {
        public int waveNum;
        public string name;
        public Sprite Image;
        public int count;
        public int attack;
        public int defense;
    }

    [CreateAssetMenu]
    public class WaveSheet : Sheet<WaveData> { }

    [Serializable]
    public class WaveRefer : ReferSheet<WaveSheet, WaveData> { }
}
