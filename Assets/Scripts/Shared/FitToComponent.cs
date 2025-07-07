using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToComponent : MonoBehaviour
{
    public RectTransform component;

    void Start()
    {
        Invoke("Fit", 0.5f);   
    }
    void Fit(){
        transform.localScale = new Vector2(component.rect.width, component.rect.height);
    }
}
