using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;

    [SerializeField]
    private Image soundImg;
    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;

    void Start()
    { 
        SaveLoader.Instance.LoadData();
        InitSound();
        soundImg.gameObject.SetActive(true);

        bestScore.text = SaveLoader.Instance.Save.maxScore.ToString("0");
    }

    public void SwitchSound()
    {
        ParameterReader.Instance.IsSoundActivated = !ParameterReader.Instance.IsSoundActivated;
        if(ParameterReader.Instance.IsSoundActivated){
            StartCoroutine(GameManager.Instance.PlayMusic(SaveLoader.Instance.Save.music));
        }else{
            GameManager.Instance.StopMusic();
        }

        InitSound();
    }

    private void InitSound()
    {
        if(ParameterReader.Instance.IsSoundActivated)
            soundImg.sprite = soundOn;
        else
            soundImg.sprite = soundOff;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
        Audio.Instance.PlaySound(Sound.Button);
    }
}
