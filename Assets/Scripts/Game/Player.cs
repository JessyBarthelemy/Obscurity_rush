using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private const int PATH_COUNT = 4;
    private float[] positions;
    private int currentStep;

    private IEnumerator moveCoroutine;
    private RectTransform rect;

    [SerializeField]
    private Battery battery;
    [SerializeField]
    private GameOverPanel gameOverPanel;
    [SerializeField]
    private BlockPool blockPool;
    [SerializeField]
    private Text bulbCountText;
    
    public void Awake()
    {
        currentStep = 2;
        rect = gameObject.GetComponent<RectTransform>();

        float width = transform.parent.GetComponent<RectTransform>().rect.width;
        float step = width / PATH_COUNT;
        
        positions = new float[PATH_COUNT];
        float currentPosition = step / 2;

        for (int i = 0; i < PATH_COUNT; i++)
        {
            positions[i] = currentPosition;
            currentPosition += step;            
        }

        rect.anchoredPosition = new Vector2(positions[currentStep], rect.anchoredPosition.y);

        bulbCountText.text = "0";        
    }

    public void OnSwipe(SwipeDirection direction)
    {
        if (direction == SwipeDirection.Left)
        {
            if (currentStep > 0)
                currentStep--;
        }
        else
        {
            if (currentStep < (positions.Length-1))
                currentStep++;
        }
            
        MoveToCurrentPosition();
    }

    private void MoveToCurrentPosition()
    {
        if(moveCoroutine != null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = MoveOverSpeed(new Vector2(positions[currentStep], rect.anchoredPosition.y), 1600);
        StartCoroutine(moveCoroutine);
    }

    public IEnumerator MoveOverSpeed(Vector2 end, float speed)
    {
        while (rect.anchoredPosition != end)
        {
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnGameOver(){
        Destroy(gameObject);
        Audio.Instance.PlaySound(Sound.Error);
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.SetBulbCount(SaveLoader.Instance.Save.bulbCount, 1, SaveLoader.Instance.Save.bulbCount + blockPool.GameData.bulbCount);
        SaveLoader.Instance.Save.bulbCount += blockPool.GameData.bulbCount;
        blockPool.OnGameOver();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        switch(other.gameObject.tag){
            case "Block":
                OnGameOver();
                break;
            case "Bulb":
                Audio.Instance.PlaySound(Sound.Coin);
                blockPool.GameData.bulbCount++;
                bulbCountText.text = blockPool.GameData.bulbCount.ToString();
                Destroy(other.gameObject);
                break;
            case "Bulb_pack":
                Audio.Instance.PlaySound(Sound.Coin);
                blockPool.GameData.bulbCount += 4;
                bulbCountText.text = blockPool.GameData.bulbCount.ToString();
                Destroy(other.gameObject);
                break;
            case "Energy":
                Audio.Instance.PlaySound(Sound.PowerUp);
                Destroy(other.gameObject);
                battery.RegainEnergy();
                blockPool.GameData.energy++;
                blockPool.GameData.energyInARow++;
                break;
            case "Energy_up":
                Audio.Instance.PlaySound(Sound.PowerUp);
                battery.Size++;
                battery.RegainEnergy();
                Destroy(other.gameObject);
                blockPool.GameData.energyUp++;
                break;
            case "Super_energy":
                Audio.Instance.PlaySound(Sound.PowerUp);
                battery.RegainFullEnergy();
                Destroy(other.gameObject);
                blockPool.GameData.superEnergy++;
                blockPool.GameData.energyInARow++;
                break;
            case "Energy_down":
                Audio.Instance.PlaySound(Sound.Penalty);
                battery.Size--;
                blockPool.GameData.energyDown++;
                Destroy(other.gameObject);
                break;
            case "Speed_down":
                Audio.Instance.PlaySound(Sound.Penalty);
                Blocks.speedBonus = 0.5f;
                Invoke("GoBackToNormalSpeed", 5f);
                Destroy(other.gameObject);
                blockPool.GameData.speedDown++;
                break;
            case "Speed_up":
                Audio.Instance.PlaySound(Sound.PowerUp);
                Blocks.speedBonus = 1.5f;
                Invoke("GoBackToNormalSpeed", 5f);
                Destroy(other.gameObject);
                blockPool.GameData.speedUp++;
                break;
        }
    }

    private void GoBackToNormalSpeed()
    {
        Blocks.speedBonus = 1f;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
            OnGameOver();
    }
}