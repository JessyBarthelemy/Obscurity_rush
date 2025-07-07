using UnityEngine;

public class SimpleBlock5 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { 2, 3, 4 }, new int[] { 1 } };
    public override int Id => 5;
    public override int Difficulty => 0;

    public SimpleBlock5(GameObject gameObject) : base(gameObject)
    {
    }
}