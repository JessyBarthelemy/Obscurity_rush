using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Text bulbCountText;

    private int futureBulbCount;
    private int bulbCount;

    public void SetBulbCount(int start, int step, int future)
    {
        bulbCount = start;
        bulbCountText.text = bulbCount.ToString();
        futureBulbCount = future;
        
        StartCoroutine(ChangeBulbCount(step));
    }

    private IEnumerator ChangeBulbCount(int step)
    {
        int min = futureBulbCount - step;
        while (bulbCount < min)
        {
            bulbCount += step;
            bulbCountText.text = bulbCount.ToString();
            yield return new WaitForSecondsRealtime(0.05f);
        }

        bulbCount = futureBulbCount;
        bulbCountText.text = bulbCount.ToString();
    }
}
