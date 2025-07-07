using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBlock1 : Block
{
    public override int[][] Compatibilities => new int[][]{new int[]{}, new int[] {2, 3, 4, 5}, new int[] { 1, 2, 3, 4, 5 }};
    public override int Id => 1;
    public override int Difficulty => 1;

    public MediumBlock1(GameObject gameObject) : base(gameObject)
    {
    }
}
