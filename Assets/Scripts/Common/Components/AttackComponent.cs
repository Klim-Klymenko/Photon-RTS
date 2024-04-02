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
            Runner.Despawn(Object);
            
            if (other.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}