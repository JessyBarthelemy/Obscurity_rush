[System.Serializable]
public class GameAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        counter++;
        return  counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}