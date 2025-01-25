using Unity.Entities;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public int level;

    private class Baker : Baker<Bubble>
    {
        public override void Bake(Bubble authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Bubble_c { level = authoring.level });
        }
    }
}
