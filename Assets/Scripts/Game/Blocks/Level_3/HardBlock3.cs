using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBlock3 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { }, new int[] {}, new int[] { 1, 2, 4 } };
    public override int Id => 3;
    public override int Difficulty => 3;

    public HardBlock3(GameObject gameObject) : base(gameObject)
    {
    }
}