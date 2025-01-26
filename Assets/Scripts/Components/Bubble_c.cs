using Unity.Entities;

public struct Bubble_c : IComponentData
{
    public int rank;
    public bool isDestroyed;
    public bool isRankedUp;
}
