﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class OriginData
    {
        public string name;

    }

    [CreateAssetMenu]
    public class OriginSheet : Sheet<OriginData> { }

    [Serializable]
    public class OriginRefer : ReferSheet<OriginSheet, OriginData> { }
}