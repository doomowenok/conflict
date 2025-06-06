using Unity.Entities;
using Unity.Mathematics;

namespace Gameplay.Core
{
    public struct UnitMoveComponent : IComponentData
    {
        public float MoveSpeed;
        public float RotationSpeed;
        public float3 TargetPosition;
    }
}