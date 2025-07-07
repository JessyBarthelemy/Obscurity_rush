using UnityEngine;

public class AdvancedBlock5 : Block
{
    public override int[][] Compatibilities => new int[][] { new int[] { }, new int[] { }, new int[] { 1, 2 , 3 ,4}, new int[] { 1, 2 , 3 } };
    public override int Id => 5;
    public override int Difficulty => 2;

    public AdvancedBlock5(GameObject gameObject) : base(gameObject)
    {
    }
}