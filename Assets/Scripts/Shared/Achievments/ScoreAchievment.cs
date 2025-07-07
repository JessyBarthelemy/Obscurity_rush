[System.Serializable]
public class ScoreAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        return gameData.score >= goal;
    }

    public override bool IsIncremental()
    {
        return false;
    }
}
