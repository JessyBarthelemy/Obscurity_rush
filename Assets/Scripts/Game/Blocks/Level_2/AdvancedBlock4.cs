using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBlock4 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { }, new int[] { 1, 2 , 3, 5}, new int[] { 1, 2 , 3 } };
    public override int Id => 4;
    public override int Difficulty => 2;

    public AdvancedBlock4(GameObject gameObject) : base(gameObject)
    {
    }
}