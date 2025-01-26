using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateBefore(typeof(BubbleCleanup))]
partial class GameStateSystem : SystemBase
{
    protected override void OnUpdate()
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
}
