[System.Serializable]
public class SkinAchievment : Achievment
{
    public override bool IsUnlocked(GameData gameData)
    {
        return SaveLoader.Instance.Save.skin == goal;
    }

    public override bool IsIncremental()
    {
        return false;
    }
}
