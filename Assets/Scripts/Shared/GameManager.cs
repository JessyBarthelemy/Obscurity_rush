using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    public int music;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        audioSource = GetComponent<AudioSource>();

        SaveLoader.Instance.LoadData();

        StartCoroutine(PlayMusic(SaveLoader.Instance.Save.music));
        DontDestroyOnLoad(this);
    }

    public IEnumerator PlayMusic(int music)
    {
        this.music = music;
        if(ParameterReader.Instance.IsSoundActivated){
            ResourceRequest resourceRequest = Resources.LoadAsync("Audio/Loop/" + music);

            while (!resourceRequest.isDone)
            {
                yield return 0;
            }

            GetComponent<AudioSource>().clip = resourceRequest.asset as AudioClip;
            audioSource.Play();
        }
    }

    public void StopMusic(){
        audioSource.Stop();
    }
}
