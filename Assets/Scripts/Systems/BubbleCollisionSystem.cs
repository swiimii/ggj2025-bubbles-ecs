using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using UnityEngine;
using Unity.Jobs;

partial struct BubbleCollisionSystem : ISystem
{

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SimulationSingleton>();
	}

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var bubble in SystemAPI.Query<RefRW<Bubble_c>>())
        {
			if( !bubble.ValueRO.isDestroyed )
            {
				state.Dependency = new CollisionJob {
					bubbleGroup = SystemAPI.GetComponentLookup<Bubble_c>()
				}.Schedule( SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency );
            }
        }
    }

	[BurstCompile]
	private struct CollisionJob : ICollisionEventsJob
	{
		public ComponentLookup<Bubble_c> bubbleGroup;
		public void Execute(CollisionEvent collisionEvent)
		{
			var entityA = collisionEvent.EntityA;
			var entityB = collisionEvent.EntityB;

			if( bubbleGroup.EntityExists(entityA) && bubbleGroup.EntityExists(entityB) && bubbleGroup.HasComponent( entityB ) &&
				bubbleGroup[entityA].rank == bubbleGroup[entityB].rank && !bubbleGroup[entityA].isDestroyed && !bubbleGroup[entityB].isDestroyed &&
				!bubbleGroup[entityA].isRankedUp && !bubbleGroup[entityB].isRankedUp )
            {
				Debug.Log($"A: {collisionEvent.EntityA}, B: {collisionEvent.EntityB}");

				// Destroy a bubble
				// TODO: Destroy the highest-position bubble
				var bubbleA = bubbleGroup[entityA];
				bubbleA.isDestroyed = true;
				bubbleGroup[entityA] = bubbleA;

				// Increment the rank of the lower bubble
				var bubbleB = bubbleGroup[entityB];
				bubbleB.isRankedUp = true;
				bubbleGroup[entityB] = bubbleB;
            }
		}
	}
}
