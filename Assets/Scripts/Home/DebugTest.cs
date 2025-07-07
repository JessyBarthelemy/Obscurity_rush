using UnityEngine;

public class DebugTest : MonoBehaviour
{
    void Update()
{
    foreach (GameObject obj in FindObjectsOfType<GameObject>())
    {
        if (obj.transform.position.x != obj.transform.position.x) // NaN check
        {
                Debug.Log("NaN position found on object: " + obj.name);
        }
    }
    }
}
