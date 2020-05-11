using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class EnemyData
    {
        public int id;
        public string name;
        public Sprite image;
        public AbilityRefer abilityData;
        public PawnType pawnType;
        
        public AbilityData ability { get { return abilityData.idxList.Count == 1 ? abilityData.Sheet[abilityData.idxList[0]] : new AbilityData(); } }
    }

    [CreateAssetMenu]
    public class EnemySheet : Sheet<EnemyData> { }
}
