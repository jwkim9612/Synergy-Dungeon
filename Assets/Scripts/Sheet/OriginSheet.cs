using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class OriginData
    {
        public Origin origin;
        public Sprite image;
        public string description;

        public string strOrigin
        {
            get
            {

                string temp = null;
                switch (origin)
                {
                    case Origin.Warrior:
                        temp = "전사";
                        break;
                    case Origin.Knight:
                        temp = "기사";
                        break;
                    case Origin.Archer:
                        temp = "궁수";
                        break;
                    case Origin.Thief:
                        temp = "도적";
                        break;
                    case Origin.Priest:
                        temp = "마법사";
                        break;
                    case Origin.Dragon:
                        temp = "드래곤";
                        break;
                }
                return temp;
            }
        }
    }

    [CreateAssetMenu]
    public class OriginSheet : Sheet<OriginData> { }

    [Serializable]
    public class OriginRefer : ReferSheet<OriginSheet, OriginData> { }
}