using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

partial struct BubbleSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach( var bubble in SystemAPI.Query<RefRO<Bubble_c>>() )
        {
            // update on bubble_c per frame.
            // use SystemAPI.Time.deltaTime instead of normal deltatime.
        }

        var bubbleJob = new BubbleJob { deltaTime = SystemAPI.Time.DeltaTime };
        bubbleJob.Schedule();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public partial struct BubbleJob : IJobEntity
    {
        public float deltaTime;
        public void Execute(Bubble_c bubble_c)
        {

        }
    }
}
