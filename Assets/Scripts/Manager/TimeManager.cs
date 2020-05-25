using GameSparks.Api.Requests;
using GameSparks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public DateTime serverTime;

    public void Initialize()
    {
        GetServerTime();
        AttendanceCheck();
        SaveLastConnectTime();
        //        GetLastConnectTime();
        //SaveLastConnectTime();
    }

    public void GetServerTime()
    {
        new LogEventRequest()
            .SetEventKey("G_ServerTime")
            .Send((response) => {
            if (!response.HasErrors)
            {
                long test2 = (long)(response.ScriptData.GetLong("ServerTime"));
                    
                Debug.Log(test2);
                Debug.Log(UnixTimeStampToDateTime(test2));
                serverTime = UnixTimeStampToDateTime(test2);

                }
                else
            {
                Debug.Log("Error Time Load !");
                Debug.Log(response.Errors.JSON);
            }
        });
    }

    private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
    }

    public DateTime ConvertFromUnixTimestamp(double timestamp)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(timestamp);
    }


    public double ConvertToUnixTimestamp(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan diff = date - origin;
        return Math.Floor(diff.TotalSeconds);
    }


    public void GetLastConnectTime()
    {
        new LogEventRequest()
            .SetEventKey("G_LastConnectTime")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //var scriptData = response.ScriptData.GetGSData("LastConnectTime");
                    var scriptData = (long)response.ScriptData.GetLong("LastConnectTime");

                    //Debug.Log("time  = " + scriptData);

                }
                else
                {
                    Debug.Log("Error LastConnectTime Load");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }

    public void SaveLastConnectTime()
    {
        new LogEventRequest()
            .SetEventKey("SaveLastConnectTime")
            .Send((response) =>
            {
            if (!response.HasErrors)
            {
                Debug.Log("Success SaveLastConnectTime !");
            }
            else
            {
                Debug.Log("Error SaveLastConnectTime !");
                Debug.Log(response.Errors.JSON);
            }
        });
    }

    public void AttendanceCheck()
    {
        new LogEventRequest()
            .SetEventKey("AttendanceCheck")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    bool result = (bool)(response.ScriptData.GetBoolean("Result"));
                    long remainingTime = (long)response.ScriptData.GetLong("RemainingTime");
                    long noLoginTime = (long)response.ScriptData.GetLong("NoLoginTime");
                    Debug.Log("남은 시간 : " + remainingTime + "    로그인 안한 시간 : " + noLoginTime);


                    if (result)
                    {
                        Debug.Log("출석하기 실행");
                    }
                    else
                    {
                        Debug.Log("출석되어있음");
                    }
                }
                else
                {
                    Debug.Log("Error AttendanceCheck");
                    Debug.Log(response.Errors.JSON);
                }
            });
    }
}
