using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockPool : MonoBehaviour
{
    private static float DEFAULT_DRAIN_SPEED = 0.15f;
    private static string GAME_COUNT = "gameCount";
    private static string TUTORIAL_PREF = "Tutorial";

    private static int poolSize = 3;
    private int difficulty = 0;
    private float batteryStep;
    private List<Block> blocks;
    private DateTime startTime;
    private System.Random random;
    private float drainSpeed;
    private int gameCount;
    public GameData GameData;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private SpriteRenderer luminosity;
    [SerializeField]
    private Battery battery;
    [SerializeField]
    private Text gameOverScoreText;
    [SerializeField]
    private Text gameOverMaxScoreText;
    [SerializeField]
    private List<Text> achievments;
    [SerializeField]
    private GameObject achievmentPanel;
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private SkinLoader skinLoader;

    private bool playAfterTuto;

    void Start()
    {
        GameData = new GameData();
        random = new System.Random();
        blocks = new List<Block>();
        gameCount = PlayerPrefs.GetInt(GAME_COUNT, 0);
        
        for (int i = 0; i < poolSize; i++)
        {
            SpawnBlock();
        }

        int showTuto = PlayerPrefs.GetInt(TUTORIAL_PREF, 0);

        if(showTuto == 0){
            playAfterTuto = true;
            Destroy(achievmentPanel.transform.parent.gameObject);
            tutorial.SetActive(true);
        }
    }

    public void OpenTuto(){
        tutorial.SetActive(true);
    }

    public void CloseTuto(){
        tutorial.SetActive(false);
        PlayerPrefs.SetInt(TUTORIAL_PREF, 1);

        if(playAfterTuto)
            StartTimer();
    }

    public void StartTimer()
    {
        Destroy(tutorial);
        skinLoader.Init();
        drainSpeed = DEFAULT_DRAIN_SPEED;
        Blocks.blockSpeed = Blocks.DEFAULT_BLOCK_SPEED;
        InvokeRepeating("CheckDifficulty", 13f, 2f);
        InvokeRepeating("GameUpdate", 0f, 0.1f);
        startTime = DateTime.Now;
    }

    private void GameUpdate(){
        battery.drain += drainSpeed * Blocks.speedBonus * Time.deltaTime;
        battery.image.fillAmount = Mathf.Lerp(1, 0, battery.drain);
        luminosity.color = new Color(luminosity.color.r, luminosity.color.g, luminosity.color.b, battery.drain);
        GameData.score = (int)((DateTime.Now - startTime).TotalSeconds * 10);
        updateScoreText();
    }

    public void updateScoreText(){
        scoreText.text = GameData.score.ToString("0");
    }

    private void CheckDifficulty()
    {
        TimeSpan span = DateTime.Now - startTime;

        if (span.TotalSeconds < 15)
        {
            difficulty = 1;
            drainSpeed = 0.2f;
        }
        else if (span.TotalSeconds < 30)
        {
            difficulty = 1;
        }
        else if (span.TotalSeconds < 45)
        {
            difficulty = 2;
        }
        else if (span.TotalSeconds < 60)
        {
            difficulty = 2;
            drainSpeed = 0.25f;
        }
        else if (span.TotalSeconds < 80)
        {
            difficulty = 3;
        }
        else if (span.TotalSeconds < 105)
        {
            difficulty = 3;
        }
        else if (span.TotalSeconds < 120)
        {
            difficulty = 3;
            drainSpeed = 0.3f;
            Blocks.blockSpeed = 3.8f;
        }
        else if (span.TotalSeconds < 140)
        {
            difficulty = 3;
            drainSpeed = 0.35f;
            Blocks.blockSpeed = 4f;
        }
        else if (span.TotalSeconds < 160)
        {
            difficulty = 3;
            drainSpeed = 0.4f;
            Blocks.blockSpeed = 4.2f;
        }
        else if (span.TotalSeconds < 200)
        {
            difficulty = 3;
            drainSpeed = 0.45f;
            Blocks.blockSpeed = 4.4f;
        }
        else if (span.TotalSeconds < 240)
        {
            difficulty = 3;
            drainSpeed = 0.5f;
            Blocks.blockSpeed = 4.6f;
        }
        else if (span.TotalSeconds < 280)
        {
            difficulty = 3;
            drainSpeed = 0.55f;
            Blocks.blockSpeed = 4.8f;
        }
        else
        {
            difficulty = 3;
            drainSpeed = 0.6f;
            Blocks.blockSpeed = 5.2f;
        }
    }

    public void SpawnBlock()
    {
        Vector3 position = Vector3.zero;
        int blockId;
        if (blocks.Count == 0)
        {
            position = transform.position;
            blockId = gameCount < 3 ? 1 : 2;
        }
        else
        {
            position = blocks[blocks.Count - 1].GameObject.GetComponent<RectTransform>().anchoredPosition;
            blockId = blocks[blocks.Count - 1].Compatibilities[difficulty][random.Next(blocks[blocks.Count - 1].Compatibilities[difficulty].Length)];    
        }

        GameObject prefab = Resources.Load<GameObject>("Prefabs/Blocks/Level_" + difficulty+"/Block_"+blockId);
        GameObject instance = Instantiate(prefab, transform);
        instance.name = "Blocks";
        
        Block block = null;

        switch(difficulty){
            case 0 :
                switch(blockId){
                    case 1 :
                        block = new SimpleBlock(instance);
                        break;
                    case 2 :
                        block = new SimpleBlock2(instance);
                        break;
                    case 3 :
                        block = new SimpleBlock3(instance);
                        break;
                    case 4:
                        block = new SimpleBlock4(instance);
                        break;
                    case 5:
                        block = new SimpleBlock5(instance);
                        break;
                }
                break;
            case 1 :
                switch(blockId){
                    case 1 :
                        block = new MediumBlock1(instance);
                        break;
                    case 2 :
                        block = new MediumBlock2(instance);
                        break;
                    case 3 :
                        block = new MediumBlock3(instance);
                        break;
                    case 4 :
                        block = new MediumBlock4(instance);
                        break;
                    case 5 :
                        block = new MediumBlock5(instance);
                        break;
                }
                break;
            case 2 :
                switch(blockId){
                    case 1 :
                        block = new AdvancedBlock1(instance);
                        break;
                    case 2 :
                        block = new AdvancedBlock2(instance);
                        break;
                    case 3 :
                        block = new AdvancedBlock3(instance);
                        break;
                    case 4 :
                        block = new AdvancedBlock4(instance);
                        break;
                    case 5 :
                        block = new AdvancedBlock5(instance);
                        break;
                }
                break;
            case 3:
                switch(blockId){
                    case 1 :
                        block = new HardBlock1(instance);
                        break;
                    case 2 :
                        block = new HardBlock2(instance);
                        break;
                    case 3 :
                        block = new HardBlock3(instance);
                        break;
                    case 4 :
                        block = new HardBlock4(instance);
                        break;
                }
                break; 
        }

        RectTransform rect = instance.GetComponent<RectTransform>();
        position.y += rect.rect.size.y;
        rect.anchoredPosition = position;

        blocks.Add(block);
    }

    public void RemoveFirstBlock()
    {
        if (blocks.Count > 0)
            blocks.RemoveAt(0);
    }

    public void OnGameOver()
    {
        gameCount++;
        PlayerPrefs.SetInt(GAME_COUNT, gameCount);

        if (GameData.score >= SaveLoader.Instance.Save.maxScore)
        {
            SaveLoader.Instance.Save.maxScore = GameData.score;
        }
        
        gameOverScoreText.text = GameData.score.ToString("0");
        gameOverMaxScoreText.text = SaveLoader.Instance.Save.maxScore.ToString("0");
        
        int achievmentCounter = 0;
        for(int i = 0; i < SaveLoader.Instance.Save.currentAchievments.Length; i++){
            if (SaveLoader.Instance.Save.currentAchievments[i].IsUnlocked(GameData))
            { 
                SaveLoader.Instance.Save.unlockedAchievments.Add(SaveLoader.Instance.Save.currentAchievments[i].id);
                SaveLoader.Instance.Save.bulbCount += SaveLoader.Instance.Save.currentAchievments[i].earning;

                achievments[achievmentCounter].text = LanguageManager.Instance.GetTranslation(SaveLoader.Instance.Save.currentAchievments[i].name);
                achievments[achievmentCounter].transform.parent.gameObject.SetActive(true);

                //Get the lowest id
                int achievmentIndex = SaveLoader.Instance.Save.currentAchievments[0].id;
                for(int j = 1; j < SaveLoader.Instance.Save.currentAchievments.Length; j++)
                {
                    if(SaveLoader.Instance.Save.currentAchievments[j].id > achievmentIndex)
                        achievmentIndex = SaveLoader.Instance.Save.currentAchievments[j].id;
                }

                if(achievmentIndex >= (Achievments.LIST.Length -1))
                {
                    SaveLoader.Instance.Save.unlockedAchievments.Clear();
                    achievmentIndex = 0;
                }
                SaveLoader.Instance.Save.currentAchievments[i] = Achievments.LIST[achievmentIndex];
                achievmentCounter++;

                SaveLoader.Instance.SaveData();
            }
        }

        SaveLoader.Instance.SaveData();
       
        difficulty = 0;
        drainSpeed = 0;
        Blocks.blockSpeed = 0;
        Blocks.speedBonus = 1;
        battery.Size = 0;
    }

    public void ReloadGame()
    {
        Audio.Instance.PlaySound(Sound.Button);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string scene)
    {
        Audio.Instance.PlaySound(Sound.Button);
        SceneManager.LoadSceneAsync(scene);
    }
}