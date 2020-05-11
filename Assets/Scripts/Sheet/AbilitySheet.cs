using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class AbilityData
    {
        public int maxHP;
        public int maxMP;
        public int attack;
        public int defense;
        public int dexterity;
        public int intellect;
    }

    [CreateAssetMenu]
    public class AbilitySheet : Sheet<AbilityData> { }

    [Serializable]
    public class AbilityRefer : ReferSheet<AbilitySheet, AbilityData> { }
}
