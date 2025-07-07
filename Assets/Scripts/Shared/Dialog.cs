using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public void ShowPanel()
    {
        Audio.Instance.PlaySound(Sound.Button);
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        Audio.Instance.PlaySound(Sound.Button);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            HidePanel();
    }
}
