using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class TribeData
    {
        public Tribe tribe;
        public Sprite image;
        public string description;
    }

    [CreateAssetMenu]
    public class TribeSheet : Sheet<TribeData> { }

    [Serializable]
    public class TribeRefer : ReferSheet<TribeSheet, TribeData> { }
}