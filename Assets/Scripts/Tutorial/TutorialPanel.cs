using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public void ShowPanel(GameObject newPanel){
        gameObject.SetActive(false);
        newPanel.SetActive(true);
    }
}
