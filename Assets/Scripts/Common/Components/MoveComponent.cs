using UnityEngine;

namespace Common.Components
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        
        [SerializeField]
        private float _speed;
        
        private void OnValidate()
        {
            _transform = transform;
        }
        
        public void Move(Vector3 direction, float deltaTime)
        {
            _transform.position += direction * (_speed * deltaTime);
        }
    }
}