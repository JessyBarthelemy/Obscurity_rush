[System.Serializable]
public class EnergyAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        if(gameData.energy > 0){
            counter += gameData.energy;
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}