using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // 파일 입출력을 위한 네임스페이스
using System.Runtime.Serialization.Formatters.Binary; // 바이너리 파일 포맷을 위한 네임스페이스

public class DataManager : MonoBehaviour
{
    private string dataPath;

    public void Initialize()
    {
        // persistentDataPath 속성은 파일을 읽고 쓸 수 있는 폴더의 경로를 반환
        dataPath = Application.persistentDataPath + "/gameData.dat";
    }

    public void Save(GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dataPath);

        GameData data = new GameData();
        data.level = gameData.level;
        data.coin = gameData.coin;

        bf.Serialize(file, data);
        file.Close();
    }

    public GameData Load()
    {
        if(File.Exists(dataPath))
        {
            // 데이터 불러오기
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            // GameData 클래스에 파일로부터 읽은 데이터를 기록(역직렬화)
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            GameData data = new GameData();

            return data;
        }
    }

    public void Reset()
    {
        GameData newGameData = new GameData();
        Save(newGameData);
    }
}
