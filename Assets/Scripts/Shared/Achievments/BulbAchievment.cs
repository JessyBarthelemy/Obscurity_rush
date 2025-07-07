[System.Serializable]
public class BulbAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        return gameData.bulbCount >= goal;
    }

    public override bool IsIncremental()
    {
        return false;
    }
}