using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Gameplay.Core
{
    public partial struct CheckReachTargetSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (unitMove, transform) in SystemAPI.Query<RefRW<UnitMoveComponent>, RefRO<LocalTransform>>())
            {
                unitMove.ValueRW.ReachTarget =
                    math.distancesq(transform.ValueRO.Position, unitMove.ValueRO.TargetPosition) < 1.0f;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}