[System.Serializable]
public class SpeedDownAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        if(gameData.speedDown > 0){
            counter += gameData.speedDown;
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}