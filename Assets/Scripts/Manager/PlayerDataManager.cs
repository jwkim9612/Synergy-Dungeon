using UnityEngine;
using geniikw.DataSheetLab;
using GameSparks.Core;
using GameSparks.Api.Requests;
using System;
using System.Linq.Expressions;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    public delegate void OnGoldChangedDelegate();
    public delegate void OnDiamondChangedDelegate();
    public OnGoldChangedDelegate OnGoldChanged { get; set; }
    public OnDiamondChangedDelegate OnDiamondChanged { get; set; }

    // 플레이어의 데이터를 관리해주는 매니저
    public PlayerData playerData;

    // 임시 생성, 플로우가 정해지면 제거
    public void Initialize()
    {
        playerData = new PlayerData
        {
            Gold = 0,
            Diamond = 0,
            Level = 1,
            PlayableStage = 1,
        };
    }

    // 게임 진입 이후 로드
    // 이후에는 재화가 소모되거나 스테이지에 입장할 때 확인하기 위해 로드하여 그 값으로 확인.
    public void LoadPlayerData()
    {
        new LogEventRequest()
            .SetEventKey("LoadPlayerData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)response.ScriptData.GetBoolean("Result");

                    if (result)
                    {
                        GSData scriptData = response.ScriptData.GetGSData("PlayerData");

                        var data = new PlayerData
                        {
                            Level = (int)scriptData.GetInt("PlayerLevel"),
                            Diamond = (int)scriptData.GetInt("PlayerDiamond"),
                            Gold = (int)scriptData.GetInt("PlayerGold"),
                            PlayableStage = (int)scriptData.GetInt("PlayerPlayableStage"),
                        };

                        playerData = data;
                        Debug.Log("Player Data Load Successfully !");
                        Debug.Log($"Level : {playerData.Level}, Gold : {playerData.Gold}, Diamond : {playerData.Diamond}, PlayableStage : {playerData.PlayableStage}");
                   
                        if(OnGoldChanged == null)
                        {
                            Debug.Log("델리게이트가 비어있습니다.");
                        }
                        else
                        {
                            OnGoldChanged();
                        }
                    }
                    else
                    {
                        Debug.Log("저장된 플레이어 데이터가 없어 새로 생성합니다.");
                        InitializePlayerData();
                    }

                }
                else
                {
                    Debug.Log("Error Player Data Load");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    // 최초 게임 진입 시에 초기 값으로 해서 저장
    // 이후에는 관련된 프로퍼티 변경할 때마다 저장
    public void SavePlayerData()
    {
        new LogEventRequest()
            .SetEventKey("SavePlayerData")
            .SetEventAttribute("Level", playerData.Level)
            .SetEventAttribute("Diamond", playerData.Diamond)
            .SetEventAttribute("Gold", playerData.Gold)
            .SetEventAttribute("PlayableStage", playerData.PlayableStage)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Success Player Data Save !");
                }
                else
                {
                    Debug.Log("Error Data Save !");
                }
            });
    }

    public void InitializePlayerData()
    {
        new LogEventRequest()
            .SetEventKey("InitializePlayerData")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Success Initialize PlayerData !");
                    LoadPlayerData();
                }
                else
                {
                    Debug.Log("Error Initialize PlayerData !");
                }
            });
    }

    //public void UseGold(int useValue)
    //{
    //    if (useValue > playerData.Gold)
    //    {
    //        Debug.Log("골드 사용값이 소유한 골드값보다 많습니다.");
    //        return;
    //    }

    //    Mathf.Clamp(playerData.Gold - useValue, 0, playerData.Gold);
    //    SavePlayerData();
    //    OnGoldChanged();
    //}

    //public void AddGold(int addValue)
    //{
    //    if(addValue < 0)
    //    {
    //        Debug.Log("더하는 양이 0보다 적을 수 없습니다.");
    //        return;
    //    }

    //    playerData.Gold += addValue;
    //    SavePlayerData();
    //    OnGoldChanged();
    //}

    //public void UseDiamond(int useValue)
    //{
    //    if (useValue > playerData.Diamond)
    //    {
    //        Debug.Log("다이아몬드 사용값이 소유한 다이아몬드값보다 많습니다.");
    //        return;
    //    }

    //    Mathf.Clamp(playerData.Diamond - useValue, 0, playerData.Diamond);
    //    SavePlayerData();
    //    OnDiamondChanged();
    //}

    //public void AddDiamond(int addValue)
    //{
    //    if (addValue < 0)
    //    {
    //        Debug.Log("더하는 양이 0보다 적을 수 없습니다.");
    //        return;
    //    }

    //    playerData.Diamond += addValue;
    //    SavePlayerData();
    //    OnDiamondChanged();
    //}
}
