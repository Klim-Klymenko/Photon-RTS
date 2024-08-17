using UnityEngine;

namespace GameEngine.Features.Movement
{
    internal sealed class MovementComponent
    {
        private readonly Transform _transform;
        private readonly float _speed;

        internal MovementComponent(Transform transform, float speed)
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