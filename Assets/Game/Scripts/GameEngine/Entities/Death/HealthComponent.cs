using System;
using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        public event Action OnDied;
        
        [SerializeField]
        private int _hitPoints;

        public void TakeDamage(int damage)
        {
            if (_hitPoints > 0)
                RpcTakeDamage(damage);
        }

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        private void RpcTakeDamage(int damage)
        {
            _hitPoints = Mathf.Max(0, _hitPoints - damage);
            
            if (_hitPoints <= 0)
                OnDied?.Invoke();
        }
    }
}