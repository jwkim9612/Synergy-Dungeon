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
    }

    public void GetServerTime()
    {
        new LogEventRequest()
            .SetEventKey("G_ServerTime")
            .Send((response) => {
            if (!response.HasErrors)
            {
                GSData scriptData = response.ScriptData.GetGSData("ServerTime");
                var timeInEpoch = scriptData.GetString("TimeInEpoch");

                Debug.Log($"{timeInEpoch}");
                Debug.Log("Success Time Load !");

            }
            else
            {
                Debug.Log("Error Time Load !");
            }
        });
    }

    private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
    }
}
