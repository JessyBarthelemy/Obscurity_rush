using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block
{   
    public abstract int[][] Compatibilities {get;}
    public abstract int Difficulty {get;}
    public abstract int Id {get;}
    public GameObject GameObject {get; private set;}

    public Block(GameObject gameObject)
    {
        GameObject = gameObject;
    }
}
