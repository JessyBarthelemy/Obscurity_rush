using UnityEngine;

public class SimpleBlock4 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { 2, 3, 5 }, new int[] { 1 } };
    public override int Id => 4;
    public override int Difficulty => 0;

    public SimpleBlock4(GameObject gameObject) : base(gameObject)
    {
    }
}