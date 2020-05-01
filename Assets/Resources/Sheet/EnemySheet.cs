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
        public int attack;
        public int defense;
    }

    [CreateAssetMenu]
    public class EnemySheet : Sheet<EnemyData> { }
}