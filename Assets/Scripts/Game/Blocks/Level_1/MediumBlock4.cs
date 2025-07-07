using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBlock4 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { 1, 2, 3, 5}, new int[] { 1, 2, 3, 4, 5 } };
    public override int Id => 4;
    public override int Difficulty => 1;

    public MediumBlock4(GameObject gameObject) : base(gameObject)
    {
    }
}
