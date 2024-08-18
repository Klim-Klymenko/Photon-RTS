using System;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(RotateComponent))]
    public sealed class MovementAgent : MonoBehaviour
    {
        [SerializeField] 
        private float stoppingDistance = 0.25f;
        
        private MoveComponent _moveComponent;
        private RotateComponent _rotateComponent;
        
        private Vector3 destination;
        private bool isMoving;

        private void Awake()
        {
            _moveComponent = this.GetComponent<MoveComponent>();
            _rotateComponent = this.GetComponent<RotateComponent>();
        }

        public void SetDestination(Vector3 targetPosition)
        {
            this.destination = targetPosition;
            this.isMoving = true;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!this.isMoving)
            {
                return;
            }

            Vector3 direction = this.destination - this.transform.position;

            if (this.IsReached(direction))
            {
                this.isMoving = false;
                return;
            }
            
            Vector3 normalizedDirection = direction.normalized;
            _moveComponent.Move(normalizedDirection, deltaTime);
            _rotateComponent.Rotate(normalizedDirection);
        }

        private bool IsReached(Vector3 direction)
        {
            return direction.sqrMagnitude <= stoppingDistance * stoppingDistance;
        }
    }
}