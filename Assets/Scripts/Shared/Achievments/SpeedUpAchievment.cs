[System.Serializable]
public class SpeedUpAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        if(gameData.speedUp > 0){
            counter += gameData.speedUp;
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}