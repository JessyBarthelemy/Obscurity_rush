using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoader : MonoBehaviour
{
    private static SaveLoader _instance;
    private string savePath;
    public Save Save {get; private set;}
 
    public static SaveLoader Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
         else 
            _instance = this;

        savePath = Application.persistentDataPath + "/gamesave.save";
        LoadData();
    }
 
    public void LoadData()
    {
        if (Save == null)
        {
            if (File.Exists(savePath))
            {
                var binaryFormatter = new BinaryFormatter();
                using (var fileStream = File.Open(savePath, FileMode.Open))
                {
                    Save = (Save)binaryFormatter.Deserialize(fileStream);
                }
            }
            else
            {
                Save = new Save();

                if (Save.currentAchievments[0] == null)
                {
                    SaveLoader.Instance.Save.currentAchievments[0] = Achievments.LIST[0];
                    SaveLoader.Instance.Save.currentAchievments[1] = Achievments.LIST[1];
                    SaveLoader.Instance.Save.currentAchievments[2] = Achievments.LIST[2];
                }
            }
        }
    }

    public void SaveData()
    { 
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, Save);
        }
    }
}
