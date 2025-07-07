using UnityEngine;

public class SkinContainer : MonoBehaviour
{
    [SerializeField]
    public RectTransform viewportRect;
    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    public GameObject child;

    void Update()
    {
        if (canvas == null)
        {
            return;
        }

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, transform.position);

        bool isVisible = RectTransformUtility.RectangleContainsScreenPoint(viewportRect, screenPoint, canvas.worldCamera);
        child.SetActive(isVisible);
    }
}
