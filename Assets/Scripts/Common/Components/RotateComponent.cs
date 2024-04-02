using UnityEngine;

namespace Common.Components
{
    public sealed class RotateComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField] 
        private float _speed;
        
        private void OnValidate()
        {
            _transform = transform;
        }

        public void Rotate(Vector3 direction, float deltaTime)
        {
            if (direction == Vector3.zero) return;
            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion smoothedRotation = Quaternion.Slerp(_transform.rotation, lookRotation, _speed * deltaTime);
            _transform.rotation = smoothedRotation;
        }
    }
}