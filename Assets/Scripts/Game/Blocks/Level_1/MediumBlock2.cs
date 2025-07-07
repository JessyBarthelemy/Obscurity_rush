using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBlock2 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] {}, new int[] {1, 3, 4, 5}, new int[] { 1, 2, 3, 4, 5 } };
    public override int Id => 2;
    public override int Difficulty => 1;

    public MediumBlock2(GameObject gameObject) : base(gameObject)
    {
    }
}