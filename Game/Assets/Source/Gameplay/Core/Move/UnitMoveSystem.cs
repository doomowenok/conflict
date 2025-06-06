using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Gameplay.Core
{
    public partial struct UnitMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (transform,
                         unit,
                         rigidbody)
                     in SystemAPI.Query<
                         RefRW<LocalTransform>,
                         RefRO<UnitMoveComponent>,
                         RefRW<PhysicsVelocity>>())
            {
                if (unit.ValueRO.ReachTarget)
                {
                    rigidbody.ValueRW.Linear = float3.zero;
                    rigidbody.ValueRW.Angular = float3.zero;
                    continue;
                }
                    
                float3 currentPosition = transform.ValueRO.Position;
                    
                float3 moveDirection = unit.ValueRO.TargetPosition - currentPosition;
                moveDirection = math.normalize(moveDirection);

                var currentRotation = transform.ValueRO.Rotation;
                var nextRotation = quaternion.LookRotation(moveDirection, math.up());
                transform.ValueRW.Rotation = math.slerp(currentRotation, nextRotation, deltaTime * unit.ValueRO.RotationSpeed);

                rigidbody.ValueRW.Linear = moveDirection * unit.ValueRO.MoveSpeed;
                rigidbody.ValueRW.Angular = float3.zero;
            }   
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}