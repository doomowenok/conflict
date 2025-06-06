using Unity.Entities;
using Unity.Mathematics;

namespace Gameplay.Core
{
    public struct InputWorldPosition : IComponentData
    {
        public float3 MouseWorldPosition;
    }
}