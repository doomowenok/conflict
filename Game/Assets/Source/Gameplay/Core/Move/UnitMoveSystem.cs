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

            foreach (var input in SystemAPI.Query<RefRO<InputWorldPosition>>())
            {
                foreach (var (localTransform,
                             unitMover,
                             physicsVelocity)
                         in SystemAPI.Query<
                             RefRW<LocalTransform>,
                             RefRO<UnitMoveComponent>,
                             RefRW<PhysicsVelocity>>())
                {
                    float3 currentPosition = localTransform.ValueRO.Position;
                    float3 targetPosition = input.ValueRO.MouseWorldPosition;
                    float3 moveDirection = targetPosition - currentPosition;
                    moveDirection = math.normalize(moveDirection);

                    var currentRotation = localTransform.ValueRO.Rotation;
                    var nextRotation = quaternion.LookRotation(moveDirection, math.up());
                    localTransform.ValueRW.Rotation = math.slerp(currentRotation, nextRotation, deltaTime * unitMover.ValueRO.RotationSpeed);

                    physicsVelocity.ValueRW.Linear = moveDirection * unitMover.ValueRO.MoveSpeed;
                    physicsVelocity.ValueRW.Angular = float3.zero;
                }   
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}