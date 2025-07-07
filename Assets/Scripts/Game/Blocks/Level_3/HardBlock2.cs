using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBlock2 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { }, new int[] {}, new int[] { 1, 3, 4 } };
    public override int Id => 2;
    public override int Difficulty => 3;

    public HardBlock2(GameObject gameObject) : base(gameObject)
    {
    }
}
