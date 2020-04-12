﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class CharacterData
    {
        /// <summary>
        /// 이름
        /// </summary>
        public string name;
        /// <summary>
        /// 종족
        /// </summary>
        public Tribe tribeEnum { get { return tribeData.idxList.Count == 1 ? tribeData.Sheet[tribeData.idxList[0]].tribe : Tribe.None; } }
        /// <summary>
        /// 태생
        /// </summary>
        public Origin originEnum { get { return originData.idxList.Count == 1 ? originData.Sheet[originData.idxList[0]].origin : Origin.None; } }

        [BigCheck(30)]
        public int attack;
        [BigCheck(30)]
        public float factor;
        [BigCheck(30)]
        public Cost cost;

        public string describe;

        [BigCheck(30)]
        [SmallCheck(10)]
        public float AttackResult
        {
            get
            {
                return attack * factor;
            }
        }
        /// <summary>
        /// 데이터 세팅 값
        /// </summary>
        public TribeRefer tribeData;
        public OriginRefer originData;
    }    

    [CreateAssetMenu]
    public class CharacterSheet : Sheet<CharacterData> { }
}