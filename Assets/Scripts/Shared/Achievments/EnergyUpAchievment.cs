[System.Serializable]
public class EnergyUpAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        if(gameData.energyUp > 0){
            counter += gameData.energyUp;
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}
