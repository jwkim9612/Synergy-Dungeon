using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace geniikw.DataSheetLab
{
    [Serializable]
    public class TribeData222
    {
        public Tribe tribe;
        public Sprite image;
        public string description;

        //public string strTribe 
        //{
        //    get 
        //    {
        //        string temp = null;
        //        switch (tribe)
        //        {
        //            case Tribe.Human:
        //                temp = "휴먼";
        //                break;
        //            case Tribe.Elf:
        //                temp = "엘프";
        //                break;
        //            case Tribe.Devil:
        //                temp = "악마";
        //                break;
        //            case Tribe.Undead:
        //                temp = "언데드";
        //                break;
        //            case Tribe.Elemental:
        //                temp = "정령";
        //                break;
        //            case Tribe.Machine:
        //                temp = "기계";
        //                break;
        //            case Tribe.Beast:
        //                temp = "야수";
        //                break;
        //        }
        //        return temp; 
        //    } 
        //}
               

}

    [CreateAssetMenu]
    public class TribeSheet : Sheet<TribeData222> { }

    [Serializable]
    public class TribeRefer : ReferSheet<TribeSheet, TribeData222> { }
}