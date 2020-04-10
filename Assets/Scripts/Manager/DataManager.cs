using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using geniikw.DataSheetLab;

public class DataManager : MonoBehaviour
{
    public CharacterSheet characterDatas;

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
