using Unity.Burst;
using Unity.Entities;

namespace Gameplay.Core
{
    public partial struct UpdateTargetPositionSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var input in SystemAPI.Query<RefRO<InputWorldPosition>>())
            {
                foreach (var unit in SystemAPI.Query<RefRW<UnitMoveComponent>>())
                {
                    unit.ValueRW.TargetPosition = input.ValueRO.MouseWorldPosition;       
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}