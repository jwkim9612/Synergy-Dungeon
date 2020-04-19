using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class CharacterData
    {
        /// <summary>
        /// 고유 아이디
        /// </summary>
        public int id;
        /// <summary>
        /// 이름
        /// </summary>
        public string name;
        /// <summary>
        /// 이미지
        /// </summary>
        public Sprite image;
        /// <summary>
        /// 종족
        /// </summary>
        public Tribe tribe { get { return tribeData.idxList.Count == 1 ? tribeData.Sheet[tribeData.idxList[0]].tribe : Tribe.None; } }
        /// <summary>
        /// 태생
        /// </summary>
        public Origin origin { get { return originData.idxList.Count == 1 ? originData.Sheet[originData.idxList[0]].origin : Origin.None; } }

        [BigCheck(30)]
        public int attack;
        [BigCheck(30)]
        public float factor;
        [BigCheck(30)]
        public Tier tier;

        public Color tierColor
        { 
            get
            {
                Color color = new Color();
                switch (tier)
                {
                    case Tier.One:
                        color = Color.gray;
                        break;
                    case Tier.Two:
                        color = Color.green;
                        break;
                    case Tier.Three:
                        color = Color.blue;
                        break;
                    case Tier.Four:
                        color = Color.red;
                        break;
                    case Tier.Five:
                        color = Color.yellow;
                        break;
                    default:
                        Debug.Log("Error SetCostBorder");
                        break;
                }
                return color;
            }
        }

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