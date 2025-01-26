using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

public class GameDefines
{
    public const float BUBBLE_RANK_SCALE = 1.5f;
    public const int BUBBLE_RANK_SCORE_MULTIPLIER = 3;

    public static bool Raycast(float3 RayFrom, float3 RayTo, out Unity.Physics.RaycastHit hit )
    {
        // Set up Entity Query to get PhysicsWorldSingleton
        // If doing this in SystemBase or ISystem, call GetSingleton<PhysicsWorldSingleton>()/SystemAPI.GetSingleton<PhysicsWorldSingleton>() directly.
        EntityQueryBuilder builder = new EntityQueryBuilder(Allocator.Temp).WithAll<PhysicsWorldSingleton>();

        EntityQuery singletonQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(builder);
        var collisionWorld = singletonQuery.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
        singletonQuery.Dispose();

        RaycastInput input = new RaycastInput()
        {
            Start = RayFrom,
            End = RayFrom + RayTo * 100,
            Filter = new CollisionFilter()
            {
                BelongsTo = ~0u,
                CollidesWith = (1u << 1),
                GroupIndex = 0
            }
        };

        hit = new Unity.Physics.RaycastHit();
        bool haveHit = collisionWorld.CastRay(input, out hit);
        if (haveHit)
        {
            return true;
        }
        return false;
    }
}
