using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBlock3 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { 1, 2, 4, 5}, new int[] { 1, 2, 3, 4, 5 } };
    public override int Id => 3;
    public override int Difficulty => 1;

    public MediumBlock3(GameObject gameObject) : base(gameObject)
    {
    }
}
