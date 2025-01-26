using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;

[UpdateAfter(typeof(BubbleCollisionSystem))]
partial class BubbleCleanup : SystemBase
{
    
    protected override void OnUpdate()
    {
        EntityCommandBuffer buffer = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (bubble, transform, entity) in SystemAPI.Query<RefRO<Bubble_c>, RefRO<LocalTransform>>().WithEntityAccess())
        {
            if ( bubble.ValueRO.isDestroyed || bubble.ValueRO.rank > GameDefines.BUBBLE_MAX_RANK )
            {
                buffer.DestroyEntity(entity);
                AudioManager.PlayAudioAtLocation(transform.ValueRO.Position);
            }
        }

        if( !buffer.IsEmpty)
        {
            buffer.Playback(EntityManager);
        }
        buffer.Dispose();
    }
}
