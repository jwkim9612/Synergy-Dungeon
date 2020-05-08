using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    private string playDataPath;
    private InGameSaveData inGameSaveData = null;

    public void Initialize()
    {
        inGameSaveData = new InGameSaveData();
        playDataPath = Path.Combine(Application.dataPath, "InGameData.json");

        if (!File.Exists(playDataPath))
        {
            //SaveSPSData();
        }
        else
        {
            //LoadSPSData();
        }
    }

    public void SaveInGameData()
    {
        Debug.Log("InGame Save Start !");
        var inGameData = PlayerDataManager.Instance.ObjectToJson(inGameSaveData);
        PlayerDataManager.Instance.CreateJsonFile(Application.dataPath, "InGameData", inGameData);
        Debug.Log("InGame Save Done !");
    }

    public void SetInGameData()
    {
        inGameSaveData.Coin = InGameManager.instance.playerState.Coin;
        inGameSaveData.Stage = GameManager.instance.stageManager.currentStage;
        inGameSaveData.Wave = GameManager.instance.stageManager.currentWave + 1;
        inGameSaveData.characterAreaInfoList = InGameManager.instance.draggableCentral.uiCharacterArea.GetAllCharacterInfo();
        inGameSaveData.prepareAreaInfoList = InGameManager.instance.draggableCentral.uiPrepareArea.GetAllCharacterInfo();
    }

    public InGameSaveData LoadInGameData()
    {
        //파일이 없으면
        if (!File.Exists(string.Format(playDataPath)))
        {
            Debug.Log(playDataPath);
            return default;
        }

        FileStream fileStream = new FileStream(string.Format(playDataPath), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<InGameSaveData>(jsonData);
    }

    /// <summary>
    /// 인게임 데이터 삭제
    /// </summary>
    /// <returns> 성공 여부 </returns>
    public bool DeleteInGameData()
    {
        if (!File.Exists(string.Format(playDataPath)))
        {
            return false;
        }

        File.Delete(playDataPath);
        return true;
    }
}
