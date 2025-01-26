using Unity.Entities;
using UnityEngine;

class BubbleSpawnConfigAuthoring : MonoBehaviour
{
    public GameObject bubblePrefab;

    class Baker : Baker<BubbleSpawnConfigAuthoring>
    {
        public override void Bake(BubbleSpawnConfigAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new BubbleSpawnConfig
            {
                bubbleSpawnEntity = GetEntity(authoring.bubblePrefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}

public struct BubbleSpawnConfig : IComponentData
{
    public Entity bubbleSpawnEntity;
}

