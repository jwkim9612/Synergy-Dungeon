using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using geniikw.DataSheetLab;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class StageData333
    {
        /// <summary>
        /// 스테이지 이름
        /// </summary>
        public string name;
        /// <summary>
        /// 스테이지 이미지
        /// </summary>
        public Sprite worldImage;
        /// <summary>
        /// 스테이지 총 웨이브
        /// </summary>
        public int totalWave;
        /// <summary>
        /// 웨이브 데이터
        /// </summary>
        public WaveRefer waveData;
    }

    [CreateAssetMenu]
    public class StageSheet : Sheet<StageData333> { }

    [Serializable]
    public class StageRefer : ReferSheet<StageSheet, StageData333> { }
}