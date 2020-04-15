using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class StageData
    {
        public string name;
        public Sprite worldImage;
    }

    [CreateAssetMenu]
    public class StageSheet : Sheet<StageData> { }

    [Serializable]
    public class StageRefer : ReferSheet<StageSheet, StageData> { }
}