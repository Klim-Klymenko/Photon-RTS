using Fusion;
using UnityEngine;

namespace Common.Components
{
    public sealed class AttackComponent : NetworkBehaviour
    {
        [SerializeField]
        private int _damage;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            
            damageable.TakeDamage(_damage);
            Runner.Despawn(Object);
        }
    }
}