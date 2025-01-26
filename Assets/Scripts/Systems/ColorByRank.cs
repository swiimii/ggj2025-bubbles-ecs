using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

partial class ColorByRank : SystemBase
{
    protected override void OnUpdate()
    {
        foreach( var (bubble, color)  in SystemAPI.Query<RefRO<Bubble_c>,RefRW<Color>>())
        {
            var rankColor = BubbleMaterialLibrary.GetColorForRank(bubble.ValueRO.rank);
            color.ValueRW.Value = new float4(
                rankColor.r,
                rankColor.g,
                rankColor.b,
                rankColor.a);
        }
        //Entities.ForEach((ref Color color, ref Bubble_c bubble) =>
        //{
            
        //}).Schedule();
    }
}
