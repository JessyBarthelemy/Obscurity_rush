using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public int id;
    public int cost;
    [SerializeField]
    private GameObject buyPanel;
    [SerializeField]
    private Text costText;
    [SerializeField]
    public string elementName;

    private bool isUnlocked;

    public bool IsUnlocked
    {
        get => isUnlocked;
        set
        {
            isUnlocked = value;
          
            if (!isUnlocked)
                costText.text = cost.ToString();
            buyPanel.SetActive(!isUnlocked);
        }
    }

    public bool isSelected;

    public void SetSelectionState(bool isSelected)
    {
        this.isSelected = isSelected;
        if (isSelected)
            GetComponent<Image>().color = new Color(0.427f, 0.116f, 0.0274f, 0.4f);
        else
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.23f);
    }
}
