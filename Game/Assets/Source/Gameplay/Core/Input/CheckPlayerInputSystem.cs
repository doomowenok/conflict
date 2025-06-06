using Unity.Entities;
using UnityEngine;

namespace Gameplay.Core
{
    public partial class CheckPlayerInputSystem : SystemBase
    {
        private Camera _camera;

        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            _camera = Camera.main;
            
            Entity entity = EntityManager.CreateEntity();
            EntityManager.AddComponent<InputDataComponent>(entity);
            EntityManager.AddComponent<InputWorldPosition>(entity);
        }

        protected override void OnUpdate()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            Entities.ForEach((ref InputDataComponent input) =>
            {
                input.MousePosition = Input.mousePosition;
                input.RayStart = ray.origin;
                input.RayDirection = ray.direction;
                input.RightMouseButtonDown = Input.GetMouseButtonDown(1);
            }).WithoutBurst().Run();
        }
    }
}