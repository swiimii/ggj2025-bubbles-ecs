using Unity.Burst;
using Unity.Entities;
using Unity.Collections;

[UpdateAfter(typeof(BubbleCollisionSystem))]
partial struct BubbleCleanup : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer buffer = new EntityCommandBuffer(Allocator.Temp);

        foreach (var bubble in SystemAPI.Query<RefRO<Bubble_c>>().WithEntityAccess())
        {
            if ( bubble.Item1.ValueRO.isDestroyed )
            {
                buffer.DestroyEntity(bubble.Item2);
            }
        }

        buffer.Playback(World.DefaultGameObjectInjectionWorld.EntityManager);
        buffer.Dispose();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
