using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField]
    private bool isSmall;

    [SerializeField]
    private bool playOnLoad = true;

    void Awake()
    {
        if (!playOnLoad)
            return;

        Init();
    }

    public void Init()
    {
        string prefabName = "";

        switch (SaveLoader.Instance.Save.skin)
        {
            case 1:
                prefabName = "Snow";
                break;
            case 2:
                prefabName = "ElectricBlue";
                break;
            case 3:
                prefabName = "Pink";
                break;
            case 4:
                prefabName = "Lava";
                break;
            case 5:
                prefabName = "Rainbow";
                break;
            case 6:
                prefabName = "Nuclear";
                break;
            case 7:
                prefabName = "Space";
                break;
            case 8:
                prefabName = "Dark";
                break;
            case 9:
                prefabName = "Poison";
                break;
            case 10:
                prefabName = "Deutschland";
                break;
            case 11:
                prefabName = "France";
                break;
            case 12:
                prefabName = "Ireland";
                break;
            case 13:
                prefabName = "Italy";
                break;
            case 14:
                prefabName = "Rusia";
                break;
            case 15:
                prefabName = "Spain";
                break;
            default:
                prefabName = "default";
                break;
        }

        InstantiateSkin(prefabName, transform, isSmall);
    }

    public static GameObject InstantiateSkin(string prefabName, Transform parent, bool isSmall){
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Skins/"+prefabName);
        prefab.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        prefab.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        GameObject animation = Instantiate(prefab, parent);
        animation.SendMessage("Init", isSmall);

        return prefab;
    }
}