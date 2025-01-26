using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class ColorAuthoring : MonoBehaviour
{
    public UnityEngine.Color value;
}


class ColorAuthoringBaker : Baker<ColorAuthoring>
{
    public override void Bake(ColorAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new Color
        {
            Value = new float4(
                authoring.value.r,
                authoring.value.g,
                authoring.value.b,
                authoring.value.a)
        });
    }
}
