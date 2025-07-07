using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public Image image;
    public float drain;

    private int size;
    public int Size {
        get {return size;}
        set
        {
            if (value < 0 || value > 2)
                return;

            size = value;

            switch (size)
            {
                case 0 :
                    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 300);
                    break;
                case 1:
                    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 400);
                    break;
                case 2:
                    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 500);
                    break;
            }
        }
    }

    public void Start()
    {
        image = transform.Find("Energy").GetComponent<Image>();
    }

    public void RegainEnergy()
    {
        drain = Mathf.Max(drain - 0.35f, 0);
    }

    public void RegainFullEnergy()
    {
        drain = 0;
    }
}
