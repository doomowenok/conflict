using Unity.Entities;
using UnityEngine;

namespace Gameplay.Core
{
    public class UnitMoverAuthoring : MonoBehaviour
    {
        public float MoveSpeed = 5.0f;
        public float RotationSpeed = 10.0f;
        
        private class UnitMoverAuthoringBaker : Baker<UnitMoverAuthoring>
        {
            public override void Bake(UnitMoverAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<UnitMoveComponent>(entity, new UnitMoveComponent
                {
                    MoveSpeed = authoring.MoveSpeed,
                    RotationSpeed = authoring.RotationSpeed,
                    TargetPosition = authoring.transform.position
                });
            }
        }
    }
}