using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Collections;

partial class ColorByRank : SystemBase
{
    protected override void OnUpdate()
    {
        foreach ( var (bubble, color, entity)  in SystemAPI.Query<RefRO<Bubble_c>,RefRW<Color>>().WithEntityAccess())
        {
            var rankColor = BubbleMaterialHelper.GetColorForRank(bubble.ValueRO.rank);
            color.ValueRW.Value = new float4(
                rankColor.r,
                rankColor.g,
                rankColor.b,
                rankColor.a);
        }

    }
}
