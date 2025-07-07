using UnityEngine;

[System.Serializable]
public abstract class Achievment
{
    public int id;
    public string name;
    public int counter;
    public int goal;
    public int earning;
    public string playId;

    public abstract bool IsUnlocked(GameData gameData);

    public abstract bool IsIncremental();
}