using Unity.Entities;
using UnityEngine;

namespace Gameplay.Core
{
    public class MoveSpeedAuthoring : MonoBehaviour
    {
        public float Value;
        
        private class MoveSpeedAuthoringBaker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<MoveSpeed>(entity, new MoveSpeed
                {
                    Value = authoring.Value
                });
            }
        }
    }
}