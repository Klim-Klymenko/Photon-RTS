using UnityEngine;
using GameEngine.Features.Health;
using GameEngine.Features.Team;

namespace GameEngine.Features.Attack
{
    internal sealed class AttackComponent : MonoBehaviour
    {
        [SerializeField] 
        private TeamComponent _teamComponent;
        
        [SerializeField]
        private int _damage;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            if (!other.TryGetComponent(out TeamComponent teamComponent)) return;
            if (_teamComponent.Team == teamComponent.Team) return;
            
            damageable.TakeDamage(_damage);
        }
    }
}