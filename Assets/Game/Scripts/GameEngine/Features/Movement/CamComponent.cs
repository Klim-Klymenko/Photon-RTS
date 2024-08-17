using UnityEngine;

namespace GameEngine.Entities.Movement
{
    internal sealed class CamComponent
    {
        private readonly Transform _transform;
        private readonly float _speed;

        internal CamComponent(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        internal void Move(Vector3 direction, float deltaTime)
        {
            _transform.position += direction * (_speed * deltaTime);
        }
    }
}