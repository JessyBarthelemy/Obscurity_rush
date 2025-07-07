using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlock3 : Block
{
    public override int[][] Compatibilities => new int[][]{new int[]{2, 4, 5}, new int[] {1} };
    public override int Id => 3;
    public override int Difficulty => 0;

    public SimpleBlock3(GameObject gameObject) : base(gameObject)
    {
    }
}