using UnityEngine;

namespace Gameplay.Core
{
    public sealed class MouseWorldPosition : MonoBehaviour
    {
        public static MouseWorldPosition Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        
        public Vector3 GetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            return plane.Raycast(ray, out float distance) ? ray.GetPoint(distance) : Vector3.zero;
        }
    }
}