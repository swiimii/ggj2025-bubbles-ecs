using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;
using Unity.Physics.Systems;

partial class BubbleSpawnSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<BubbleSpawnConfig>();
    }
    protected override void OnUpdate()
    {
        if ( Input.GetButtonDown("Fire1") )
        {
            Debug.Log("Attempt");
            if( GameDefines.Raycast( Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction, out var hit ))
            {
                Debug.Log("Hit!");
                var bubbleSpawnConfig = SystemAPI.GetSingleton<BubbleSpawnConfig>();
                Entity spawnedBubble = EntityManager.Instantiate(bubbleSpawnConfig.bubbleSpawnEntity);
                int rank = EntityManager.GetComponentData<Bubble_c>(spawnedBubble).rank;
                EntityManager.SetComponentData(spawnedBubble, new LocalTransform {
                    Position = hit.Position,
                    Rotation = Quaternion.identity,
                    Scale = rank * GameDefines.BUBBLE_RANK_SCALE
                });
            }
        }
    }
}
