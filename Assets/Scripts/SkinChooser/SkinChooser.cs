using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinChooser : MonoBehaviour
{
    [SerializeField]
    private Text bulbCount;

    [SerializeField]
    private SkinDialog dialog;

    private int futureBulbCount;

    void Start()
    {
        bulbCount.text = SaveLoader.Instance.Save.bulbCount.ToString();
    }

    public void OnSkinSelection(Skin selectedSkin)
    {
        if (selectedSkin.IsUnlocked)
        {
            Skin[] skins = FindObjectsOfType<Skin>();
            foreach (Skin skin in skins)
            {
                if (skin.id == selectedSkin.id)
                {
                    skin.SetSelectionState(true);
                    SaveLoader.Instance.Save.skin = selectedSkin.id;
                    SaveLoader.Instance.SaveData();
                }      
                else if (skin.isSelected)
                    skin.SetSelectionState(false);
            }
        }
        else
        {
            dialog.ShowDialog(selectedSkin);
        }
    }

    public void OnMusicSelection(Music selectedMusic)
    {
        StartCoroutine(GameManager.Instance.PlayMusic(selectedMusic.id));

        if (selectedMusic.IsUnlocked)
        {
            Music[] musics = FindObjectsOfType<Music>();
            foreach (Music music in musics)
            {
                if (music.id == selectedMusic.id)
                {
                    music.SetSelectionState(true);
                    SaveLoader.Instance.Save.music = selectedMusic.id;
                    SaveLoader.Instance.SaveData();
                }
                else if (music.isSelected)
                    music.SetSelectionState(false);
            }
        }
        else
        {
            dialog.ShowDialog(selectedMusic);
        }
    }

    public void BuySkin(Skin skin)
    {
        if (skin != null)
        {
            if (SaveLoader.Instance.Save.bulbCount >= skin.cost)
            {
                Audio.Instance.PlaySound(Sound.Unlock);
                int step = 10;
                if (skin.cost > 200)
                    step = 20;

                SetBulbCount(step, SaveLoader.Instance.Save.bulbCount - skin.cost, false);
                skin.IsUnlocked = true;
                SaveLoader.Instance.Save.AddSkin(skin.id);
                SaveLoader.Instance.SaveData();
                OnSkinSelection(skin);
            }
            else
            {
                Audio.Instance.PlaySound(Sound.Error);
            }
        }
    }

    public void BuyMusic(Music music)
    {
        if (music != null)
        {
            SaveLoader.Instance.Save.bulbCount = 1000;
            if (SaveLoader.Instance.Save.bulbCount >= music.cost)
            {
                Audio.Instance.PlaySound(Sound.Unlock);
                int step = 10;
                if (music.cost > 200)
                    step = 20;

                SetBulbCount(step, SaveLoader.Instance.Save.bulbCount - music.cost, false);
                music.IsUnlocked = true;
                SaveLoader.Instance.Save.AddMusic(music.id);
                SaveLoader.Instance.SaveData();
                OnMusicSelection(music);
            }
            else
            {
                Audio.Instance.PlaySound(Sound.Error);
            }
        }
    }

    public void SetBulbCount(int step, int future, bool addBulb)
    {
        futureBulbCount = future;
        StartCoroutine(ChangeBulbCount(step, addBulb));
    }

    private IEnumerator ChangeBulbCount(int step, bool addBulb)
    {
        if (addBulb)
        {
            int min = futureBulbCount - step;
            while (SaveLoader.Instance.Save.bulbCount < min)
            {
                SaveLoader.Instance.Save.bulbCount += step;
                bulbCount.text = SaveLoader.Instance.Save.bulbCount.ToString();
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            int min = futureBulbCount + step;
            while (SaveLoader.Instance.Save.bulbCount > min)
            {
                SaveLoader.Instance.Save.bulbCount -= step;
                bulbCount.text = SaveLoader.Instance.Save.bulbCount.ToString();
                yield return new WaitForSeconds(0.05f);
            }
        }

        SaveLoader.Instance.Save.bulbCount = futureBulbCount;
        bulbCount.text = SaveLoader.Instance.Save.bulbCount.ToString();
    }

    public void LoadScene(string scene)
    {
        Audio.Instance.PlaySound(Sound.Button);
        if (GameManager.Instance.music != SaveLoader.Instance.Save.music) 
            StartCoroutine(GameManager.Instance.PlayMusic(SaveLoader.Instance.Save.music));
        SceneManager.LoadSceneAsync(scene);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            LoadScene("Home");
    }
}
