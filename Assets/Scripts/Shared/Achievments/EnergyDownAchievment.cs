[System.Serializable]
public class EnergyDownAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        if(gameData.energyDown > 0){
            counter += gameData.energyDown;
        }

        return counter >= goal;
    }

    public override bool IsIncremental()
    {
        return true;
    }
}