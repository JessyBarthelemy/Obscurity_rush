public class Music : Element
{
    void Awake()
    {
        IsUnlocked = id == 0;

        if (!IsUnlocked && SaveLoader.Instance.Save.boughtMusic != null)
            IsUnlocked = SaveLoader.Instance.Save.boughtMusic.Contains(id);

        if (IsUnlocked && id == SaveLoader.Instance.Save.music)
        {
            isSelected = true;
            SetSelectionState(true);
        }
    }
}
