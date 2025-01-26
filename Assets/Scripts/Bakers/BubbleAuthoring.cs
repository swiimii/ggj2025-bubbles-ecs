using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

public class BubbleAuthoring : MonoBehaviour
{
    [SerializeField] int rank = 1;

    private void Start()
    {
        //transform.localScale = Vector3.one * 2;
    }

    public void InitializeBubble(int rank)
    {
        this.rank = rank;
    }

    private class Baker : Baker<BubbleAuthoring>
    {
        public override void Bake(BubbleAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Bubble_c { 
                rank = authoring.rank,
                isDestroyed = false
            });

            authoring.transform.localScale = Vector3.one * authoring.rank * GameDefines.BUBBLE_RANK_SCALE;
        }
    }
}
