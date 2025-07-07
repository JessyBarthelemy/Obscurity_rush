using UnityEngine;

public class SimpleBlock2 : Block
{
    public override int[][] Compatibilities => new int[][]{new int[]{3, 4, 5}, new int[] {1} };
    public override int Id => 2;
    public override int Difficulty => 0;

    public SimpleBlock2(GameObject gameObject) : base(gameObject)
    {
    }
}