using System;
using UnityEngine;

[System.Serializable]
public class DailyGameAchievment : Achievment
{
    private const string DATE_FORMAT = "ddMMyyyy";
    private const string LAST_PLAY_DATE = "LastPlayDate";

    public override bool IsUnlocked(GameData gameData)
    {
        string yesterday = DateTime.Now.AddDays(-1).ToString(DATE_FORMAT);
        if (yesterday == PlayerPrefs.GetString(id+LAST_PLAY_DATE, yesterday))
        {
            counter++;
            PlayerPrefs.SetString(id+LAST_PLAY_DATE, DateTime.Now.ToString(DATE_FORMAT));
        }    
        else if(PlayerPrefs.GetString(id+LAST_PLAY_DATE, yesterday) != DateTime.Now.ToString(DATE_FORMAT)){
            counter = 1;
            PlayerPrefs.SetString(id+LAST_PLAY_DATE, DateTime.Now.ToString(DATE_FORMAT));
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}