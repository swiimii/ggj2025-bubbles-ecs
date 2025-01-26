using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(BubbleCollisionSystem))]
partial class RankUpSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var (bubble, transform) in SystemAPI.Query<RefRW<Bubble_c>, RefRW<LocalTransform>>())
        {
            if (!bubble.ValueRO.isDestroyed && bubble.ValueRO.isRankedUp)
            {
                GameLoop.IncrementScore(bubble.ValueRO.rank * GameDefines.BUBBLE_RANK_SCORE_MULTIPLIER);
                bubble.ValueRW.rank += 1;
                bubble.ValueRW.isRankedUp = false;
                transform.ValueRW.Scale = bubble.ValueRW.rank * GameDefines.BUBBLE_RANK_SCALE;
                transform.ValueRW.Position += new Unity.Mathematics.float3(0,1,0) * bubble.ValueRW.rank;
            }
        }
    }
}
