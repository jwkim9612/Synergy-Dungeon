using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class CharacterData22
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

        public AbilityRefer oneStarAbilityData;
        public AbilityRefer twoStarAbilityData;
        public AbilityRefer threeStarAbilityData;

        public AbilityData oneStarAbility { get { return oneStarAbilityData.idxList.Count == 1 ? oneStarAbilityData.Sheet[oneStarAbilityData.idxList[0]] : new AbilityData(); } }
        public AbilityData twoStarAbility { get { return twoStarAbilityData.idxList.Count == 1 ? twoStarAbilityData.Sheet[twoStarAbilityData.idxList[0]] : new AbilityData(); } }
        public AbilityData threeStarAbility { get { return threeStarAbilityData.idxList.Count == 1 ? threeStarAbilityData.Sheet[threeStarAbilityData.idxList[0]] : new AbilityData(); } }

        public AbilityData GetAbilityDataByStar(int star)
        {
            AbilityData abilityData = null;

            switch (star)
            {
                case 1:
                    abilityData = oneStarAbility;
                    break;
                case 2:
                    abilityData = twoStarAbility;
                    break;
                case 3:
                    abilityData = threeStarAbility;
                    break;
                default:
                    Debug.Log("Error GetAbilityDataByStar");
                    break;
            }

            return abilityData;
        }

        [BigCheck(30)]
        public Tier tier;
        public string describe;
        public PawnType pawnType;

        /// <summary>
        /// 데이터 세팅 값
        /// </summary>
        public TribeRefer tribeData;
        public OriginRefer originData;
    }

    [CreateAssetMenu]
    public class CharacterSheet : Sheet<CharacterData22> { }
}