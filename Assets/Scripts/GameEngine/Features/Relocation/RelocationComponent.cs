using Fusion;
using GameEngine.Features.Team;
using UnityEngine;

namespace GameEngine.Features.Relocation
{
    public sealed class RelocationComponent : NetworkBehaviour
    {
        [SerializeField]
        private TeamComponent _teamComponent;
        
        [SerializeField] 
        private float _stoppingDistance = 1.5f;

        [SerializeField] 
        private float _movementSpeed = 5.0f;
        
        [SerializeField]
        private float _rotationSpeed = 0.1f;
        
        private Vector3 _targetPosition;
        private bool _isMoving;

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            _isMoving = true;
        }
        
        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        public void RpcSetTargetPosition(Vector3 position)
        {
            SetTargetPosition(position);
        }
        
        public override void FixedUpdateNetwork()
        {
            if (!_isMoving) return;
            
            Vector3 direction = _targetPosition - transform.position;

            if (IsReached(direction))
            {
                _isMoving = false;
                return;
            }
            
            Vector3 normalizedDirection = direction.normalized;
            
            Move(normalizedDirection);
            Rotate(normalizedDirection);
        }

        private void Move(Vector3 normalizedDirection)
        {
            transform.position += normalizedDirection * (_movementSpeed * Runner.DeltaTime);
        }

        private void Rotate(Vector3 normalizedDirection)
        {
            Quaternion lookRotation = Quaternion.LookRotation(normalizedDirection);
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed);
            transform.rotation = smoothedRotation;
        }
        
        private bool IsReached(Vector3 direction)
        {
            return direction.sqrMagnitude <= _stoppingDistance * _stoppingDistance;
        }
    }
}