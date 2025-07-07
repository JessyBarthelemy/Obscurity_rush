using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField]
    private BlockPool blockPool;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Super_energy" || collider.gameObject.name == "Energy")
        {
            blockPool.GameData.energyInARow = 0;
        }
        else if(collider.gameObject.name == "Blocks")
        {
            blockPool.RemoveFirstBlock();
            blockPool.SpawnBlock();
            Destroy(collider.gameObject);
        }
    }
}
