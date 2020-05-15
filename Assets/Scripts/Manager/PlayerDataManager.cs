using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using geniikw.DataSheetLab;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    // 플레이어의 데이터를 관리해주는 매니저
    public PlayerData playerData;

    public void Initialize()
    {
        PlayerData loadedPlayerData = JsonDataManager.Instance.LoadJsonFile<PlayerData>(Application.dataPath, "PlayerData");
        if(loadedPlayerData == null)
        {
            loadedPlayerData = new PlayerData();
            JsonDataManager.Instance.CreateJsonFile(Application.dataPath, "PlayerData", JsonDataManager.Instance.ObjectToJson(loadedPlayerData));
        }
        playerData = loadedPlayerData;
    }

    public void SavePlayerData()
    {
        Debug.Log("플레이어 정보 저장 완료!");
        JsonDataManager.Instance.CreateJsonFile(Application.dataPath, "PlayerData", JsonDataManager.Instance.ObjectToJson(playerData));
    }
}
