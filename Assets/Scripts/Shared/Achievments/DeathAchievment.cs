[System.Serializable]
public class DeathAchievment : Achievment
{
    public int minimum;

    public override bool IsUnlocked(GameData gameData)
    {
        return gameData.score >= minimum && gameData.score <= goal;
    }

    public override bool IsIncremental()
    {
        return false;
    }
}