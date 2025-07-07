using UnityEngine;

public class Skin : Element
{
    void Awake()
    {
        IsUnlocked = id == 0;

        if (!IsUnlocked && SaveLoader.Instance.Save.boughtSkin != null)
            IsUnlocked = SaveLoader.Instance.Save.boughtSkin.Contains(id);

        if (IsUnlocked && id == SaveLoader.Instance.Save.skin)
        {
            isSelected = true;
            SetSelectionState(true);
        }
    }
}
