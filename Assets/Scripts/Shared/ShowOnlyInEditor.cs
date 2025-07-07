using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnlyInEditor : MonoBehaviour
{
    #if UNITY_EDITOR || DEVELOPMENT_BUILD
    void Awake()
    {
        Destroy(gameObject);
    }
    #endif
}
