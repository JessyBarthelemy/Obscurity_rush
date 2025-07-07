[System.Serializable]
public class ScoreWithAllEnergyAchievment : Achievment
{
    public int minimum;

    public override bool IsUnlocked(GameData gameData)
    {
        return gameData.energyInARow >= goal;
    }

    public override bool IsIncremental()
    {
        return false;
    }
}