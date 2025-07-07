using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public static readonly float DEFAULT_BLOCK_SPEED = 3.6f;
    public static float blockSpeed;
    public static float speedBonus = 1;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * blockSpeed * speedBonus);
    }
}