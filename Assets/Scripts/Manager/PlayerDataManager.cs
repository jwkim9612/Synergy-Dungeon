using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using geniikw.DataSheetLab;

public class PlayerDataManager : MonoBehaviour
{
    // 플레이어의 데이터를 관리해주는 매니저
    public PlayerData playerData;

    public void Initialize()
    {
        PlayerData loadedPlayerData = LoadJsonFile<PlayerData>(Application.dataPath, "PlayerData");
        if(loadedPlayerData == null)
        {
            loadedPlayerData = new PlayerData();
            CreateJsonFile(Application.dataPath, "PlayerData", ObjectToJson(loadedPlayerData));
        }
        playerData = loadedPlayerData;
    }

    public string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        //파일이 없으면
        if(!File.Exists(string.Format("{0}/{1}.json", loadPath, fileName)))
        {
            return default;
        }

        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
