using UnityEngine;
using UnityEngine.UI;

public class BackgroundDrawer : MonoBehaviour
{
    void Awake()
    {
        RawImage img = GetComponent<RawImage>();
        Texture2D backgroundTexture = new Texture2D(1, 2);
        
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;

        backgroundTexture.SetPixels(new Color[] { new Color(0.686f, 0.282f, 0.098f), new Color(0.956f, 0.623f, 0.235f) });
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
}
