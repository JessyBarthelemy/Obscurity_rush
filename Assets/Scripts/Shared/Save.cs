using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Save
{
    public double maxScore;
    public int bulbCount;
    public int skin;
    public int music;
    public HashSet<int> boughtSkin;
    public HashSet<int> boughtMusic;
    public HashSet<int> unlockedAchievments;
    public Achievment[] currentAchievments;

    public Save()
    {
        boughtSkin = new HashSet<int>();
        boughtMusic = new HashSet<int>();
        unlockedAchievments = new HashSet<int>();
        currentAchievments = new Achievment[3];
    }

    public void AddSkin(int i)
    {
        boughtSkin.Add(i);
    }

    public void AddMusic(int i)
    {
        boughtMusic.Add(i);
    }
}
