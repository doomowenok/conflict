using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using RaycastHit = Unity.Physics.RaycastHit;

namespace Gameplay.Core
{
    [BurstCompile]
    public partial struct ScreenToWorldInputSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PhysicsWorldSingleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            PhysicsWorld physics = SystemAPI.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
            
            foreach (var (inputDataComponent, 
                         inputWorldPosition) in
                     SystemAPI.Query<
                         RefRO<InputDataComponent>,
                         RefRW<InputWorldPosition>>())
            {
                if (inputDataComponent.ValueRO.RightMouseButtonDown)
                {
                    RaycastInput raycast = new RaycastInput
                    {
                        Start = inputDataComponent.ValueRO.RayStart,
                        End = inputDataComponent.ValueRO.RayDirection * 1000.0f,
                        Filter = new CollisionFilter()
                        {
                            BelongsTo = 1,
                            CollidesWith = 1,
                            GroupIndex = 0
                        },
                    };

                    if (physics.CastRay(raycast, out RaycastHit hit))
                    {
                        float3 position = hit.Position;
                        inputWorldPosition.ValueRW.MouseWorldPosition = position;
                    }   
                }
            }
        }
    }
}