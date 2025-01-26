using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateBefore(typeof(BubbleCleanup))]
partial struct GameStateSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ( var (bubble, transform) in SystemAPI.Query<RefRW<Bubble_c>, RefRO<LocalTransform>>())
        {
            if (!bubble.ValueRW.isDestroyed && transform.ValueRO.Position.y < -4)
            {
                bubble.ValueRW.isDestroyed = true;
                UnityEngine.Debug.Log("THEN FALL BUBBLE");
                GameLoop.LoseGame();
            }
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

}
