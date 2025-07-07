using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class AchievmentPanel : MonoBehaviour
{
    [SerializeField]
    private Text firstAchievment;
    [SerializeField]
    private Text firstAchievmentBulb;
    [SerializeField]
    private Text secondAchievment;
    [SerializeField]
    private Text secondAchievmentBulb;
    [SerializeField]
    private Text thirdAchievment;
    [SerializeField]
    private Text thirdAchievmentBulb;
    [SerializeField]
    private BlockPool blockPool;

    void Start()
    {
        Debug.Log("JBA");
        Debug.Log(SaveLoader.Instance.Save.currentAchievments[0]);
        firstAchievment.text = FormatText(SaveLoader.Instance.Save.currentAchievments[0]);
        firstAchievmentBulb.text = SaveLoader.Instance.Save.currentAchievments[0].earning.ToString();

        secondAchievment.text = FormatText(SaveLoader.Instance.Save.currentAchievments[1]);
        secondAchievmentBulb.text = SaveLoader.Instance.Save.currentAchievments[1].earning.ToString();

        thirdAchievment.text = FormatText(SaveLoader.Instance.Save.currentAchievments[2]);
        thirdAchievmentBulb.text = SaveLoader.Instance.Save.currentAchievments[2].earning.ToString();   
    }

    public void CloseAchievmentPanel()
    {
        Audio.Instance.PlaySound(Sound.Button);
        gameObject.SetActive(false);
        blockPool.StartTimer();
        Destroy(transform.parent.gameObject);
    }

    private string FormatText(Achievment ach){
        if(ach.IsIncremental())
        {
            StringBuilder sb = new StringBuilder(LanguageManager.Instance.GetTranslation(ach.name));
            sb.Append(" (");
            sb.Append(ach.counter);
            sb.Append("/");
            sb.Append(ach.goal);
            sb.Append(")");
            return sb.ToString();
        }
        else
            return LanguageManager.Instance.GetTranslation(ach.name);
    }
}
