using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using geniikw.DataSheetLab;

public class PlayerDataManager : MonoBehaviour
{
    // 플레이어의 데이터를 관리해주는 매니저

    public void Initialize()
    {
        
    }

    string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    T JsonToObject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

}
