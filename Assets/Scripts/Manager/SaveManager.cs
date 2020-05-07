using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveManager
{
    private static SaveManager instance = null;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveManager();
            }
            return instance;
        }
    }

    private string playDataPath;
    private InGameSaveData inGameSaveData = null;

    public void Initialize()
    {
        inGameSaveData = new InGameSaveData();
        playDataPath = Path.Combine(Application.persistentDataPath, "InGameData.dat");

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
        PlayerDataManager.Instance.CreateJsonFile(Application.dataPath, "InGameData.dat", inGameData);
        Debug.Log("InGame Save Done !");
    }

    public void SetInGameData(List<Character> characters, List<Enemy> enemies)
    {
        inGameSaveData.Characters = characters;
        inGameSaveData.Enemies = enemies;
    }
}
