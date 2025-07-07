using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlock : Block
{
    public override int[][] Compatibilities => new int[][]{new int[]{2, 3, 4, 5} };
    public override int Id => 1;
    public override int Difficulty => 0;

    public SimpleBlock(GameObject gameObject) : base(gameObject)
    {
    }
}