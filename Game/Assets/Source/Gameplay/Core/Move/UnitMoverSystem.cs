using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
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
            foreach (var (localTransform,
                         moveSpeed,
                         physicsVelocity)
                     in SystemAPI.Query<
                         RefRW<LocalTransform>,
                         RefRO<MoveSpeed>,
                         RefRW<PhysicsVelocity>>())
            {
                float3 targetPosition = localTransform.ValueRO.Position + new float3(10.0f, 0.0f, 0.0f);
                float3 moveDirection = targetPosition - localTransform.ValueRO.Position;
                moveDirection = math.normalize(moveDirection);
                
                localTransform.ValueRW.Rotation = quaternion.LookRotation(moveDirection, math.up());

                physicsVelocity.ValueRW.Linear = moveDirection * moveSpeed.ValueRO.Value;
                physicsVelocity.ValueRW.Angular = float3.zero;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}