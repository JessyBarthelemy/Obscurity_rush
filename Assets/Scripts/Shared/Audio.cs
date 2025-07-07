using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    public static Audio Instance;

    public AudioClip buttonSound;
    public AudioClip errorSound;
    public AudioClip unlockSound;
    public AudioClip powerUpSound;
    public AudioClip coinSound;
    public AudioClip penaltySound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(Sound sound)
    {
        if(!ParameterReader.Instance.IsSoundActivated)
            return;

        switch (sound)
        {
            case Sound.PowerUp:
                audioSource.PlayOneShot(powerUpSound);
                break;
            case Sound.Error:
                audioSource.PlayOneShot(errorSound);
                break;
            case Sound.Unlock:
                audioSource.PlayOneShot(unlockSound);
                break;
            case Sound.Coin:
                audioSource.PlayOneShot(coinSound);
                break;
            case Sound.Penalty:
                audioSource.PlayOneShot(penaltySound);
                break;
            default:
                audioSource.PlayOneShot(buttonSound);
                break;
        }       
    }
}
