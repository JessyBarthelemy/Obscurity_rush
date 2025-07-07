using UnityEngine;
using UnityEngine.UI;

public class SkinDialog : MonoBehaviour
{
    private Skin skin;
    private Music music;
    [SerializeField]
    private Text text;
    [SerializeField]
    private SkinChooser skinChooser;

    public void ShowDialog(Skin skin){
        Audio.Instance.PlaySound(Sound.Button);
        this.skin = skin;
        text.text = LocalizedText.Translate("buy_confirm_skin", LocalizedText.Translate(skin.elementName));
        gameObject.SetActive(true);
    }

    public void BuySkin(){
        if(skin != null)
            skinChooser.BuySkin(skin);
        else if (music != null)
            skinChooser.BuyMusic(music);
        CloseDialog();  
    }

    public void ShowDialog(Music music)
    {
        Audio.Instance.PlaySound(Sound.Button);
        this.music = music;
        text.text = LocalizedText.Translate("buy_confirm_music", LocalizedText.Translate(music.elementName));
        gameObject.SetActive(true);
    }

    public void BuyMusic()
    {
        skinChooser.BuyMusic(music);
        CloseDialog();
    }

    public void CloseDialog(){
        Audio.Instance.PlaySound(Sound.Button);
        this.skin = null;
        this.music = null;
        gameObject.SetActive(false);
    }
}
