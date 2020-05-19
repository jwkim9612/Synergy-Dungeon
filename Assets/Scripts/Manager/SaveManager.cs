using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    private string playDataPath;
    private InGameSaveData _inGameSaveData;
    public InGameSaveData inGameSaveData { get { return _inGameSaveData; } }

    public void Initialize()
    {
        _inGameSaveData = new InGameSaveData();

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
        JsonDataManager.Instance.CreateJsonFile(Application.dataPath, "InGameData", JsonDataManager.Instance.ObjectToJson(inGameSaveData));
        Debug.Log("InGame Save Done !");
    }

    public void SetInGameData()
    {
        _inGameSaveData.coin = InGameManager.instance.playerState.coin;
        _inGameSaveData.chapter = StageManager.Instance.currentChapter;
        _inGameSaveData.wave = StageManager.Instance.currentWave + 1;
        _inGameSaveData.characterAreaInfoList = InGameManager.instance.draggableCentral.uiCharacterArea.GetAllCharacterInfo();
        _inGameSaveData.prepareAreaInfoList = InGameManager.instance.draggableCentral.uiPrepareArea.GetAllCharacterInfo();
    }

    public void LoadInGameData()
    {
        //파일이 없으면
        if (!HasInGameData())
        {
            Debug.Log(playDataPath);
            return;
        }

        FileStream fileStream = new FileStream(string.Format(playDataPath), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        Debug.Log("!! Load");
        string jsonData = Encoding.UTF8.GetString(data);
        _inGameSaveData = JsonConvert.DeserializeObject<InGameSaveData>(jsonData);
    }

    /// <summary>
    /// 인게임 데이터 삭제
    /// </summary>
    /// <returns> 성공 여부 </returns>
    public bool DeleteInGameData()
    {
        if (HasInGameData())
        {
            File.Delete(playDataPath);
            return true;
        }

        return false;
    }

    public bool HasInGameData()
    {
        return File.Exists(string.Format(playDataPath));
    }
}
