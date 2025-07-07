using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Vector3 initialPosition;
    private float drain;

    [SerializeField]
    private SpriteRenderer luminosity;

    [SerializeField]
    private Image battery;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2);
        luminosity.color = new Color(luminosity.color.r, luminosity.color.g, luminosity.color.b, drain);
        battery.fillAmount = Mathf.Lerp(1, 0, drain);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        switch(other.gameObject.tag){
            case "Player":
                transform.position = initialPosition;
                drain = 0;
                luminosity.color = new Color(luminosity.color.r, luminosity.color.g, luminosity.color.b, 0);
                battery.fillAmount = 1;
                break;
        }
    }
}
