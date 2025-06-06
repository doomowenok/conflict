using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Gameplay.Core
{
    public partial struct UnitMoverSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        // [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            Vector3 mousePosition = MouseWorldPosition.Instance.GetPosition();
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (localTransform,
                         moveSpeed,
                         physicsVelocity)
                     in SystemAPI.Query<
                         RefRW<LocalTransform>,
                         RefRO<MoveSpeed>,
                         RefRW<PhysicsVelocity>>())
            {
                float3 targetPosition = mousePosition;
                float3 moveDirection = targetPosition - localTransform.ValueRO.Position;
                moveDirection = math.normalize(moveDirection);

                var currentRotation = localTransform.ValueRO.Rotation;
                var nextRotation = quaternion.LookRotation(moveDirection, math.up());
                localTransform.ValueRW.Rotation = math.slerp(currentRotation, nextRotation, deltaTime * 10);

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