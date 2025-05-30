using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Gameplay.Core
{
    public partial struct UnitMoverSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (localTransform,
                         moveSpeed)
                     in SystemAPI.Query<
                         RefRW<LocalTransform>,
                         RefRO<MoveSpeed>>())
            {
                localTransform.ValueRW.Position =
                    localTransform.ValueRO.Position +
                    new float3(moveSpeed.ValueRO.Value, 0.0f, 0.0f) * deltaTime;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}