using Unity.Entities;
using Unity.Mathematics;

namespace Gameplay.Core
{
    public struct InputDataComponent : IComponentData
    {
        public float3 MousePosition;
        public float3 RayStart;
        public float3 RayDirection;
        public bool RightMouseButtonDown;
    }
}