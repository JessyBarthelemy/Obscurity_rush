using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBlock1 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { }, new int[] {}, new int[] { 2 , 3, 4 } };
    public override int Id => 1;
    public override int Difficulty => 3;

    public HardBlock1(GameObject gameObject) : base(gameObject)
    {
    }
}