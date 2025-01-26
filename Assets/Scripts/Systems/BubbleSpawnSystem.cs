using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;


partial class BubbleSpawnSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<BubbleSpawnConfig>();
    }
    protected override void OnUpdate()
    {
        if( Input.GetButtonDown("Fire1") )
        {
            if( Physics.Raycast(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction, out var hit, 100, 1 << LayerMask.NameToLayer("ContainerMouth") ) )
            {
                Debug.Log("Hit!");
                var bubbleSpawnConfig = SystemAPI.GetSingleton<BubbleSpawnConfig>();
                Entity spawnedBubble = EntityManager.Instantiate(bubbleSpawnConfig.bubbleSpawnEntity);
                int rank = EntityManager.GetComponentData<Bubble_c>(spawnedBubble).rank;
                EntityManager.SetComponentData(spawnedBubble, new LocalTransform {
                    Position = hit.point,
                    Rotation = Quaternion.identity,
                    Scale = rank * GameDefines.BUBBLE_RANK_SCALE
                });
            }
        }
    }
}
