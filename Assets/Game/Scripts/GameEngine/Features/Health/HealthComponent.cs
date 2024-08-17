using System;
using Fusion;
using UnityEngine;

namespace GameEngine.Features.Health
{
    internal sealed class HealthComponent : NetworkBehaviour, IDamageable
    {
        public event Action<NetworkObject> OnDied;
        
        [SerializeField]
        private int _hitPoints;
        
        [SerializeField]
        private int _minHitPoints;

        public void TakeDamage(int damage)
        {
            if (_hitPoints > _minHitPoints)
                RpcTakeDamage(damage);
        }

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        private void RpcTakeDamage(int damage)
        {
            _hitPoints = Mathf.Max(_minHitPoints, _hitPoints - damage);
            
            if (_hitPoints <= _minHitPoints)
                OnDied?.Invoke(Object);
        }
    }
}