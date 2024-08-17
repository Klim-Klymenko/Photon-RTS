using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(TeamComponent))]
    public sealed class AttackComponent : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        
        private TeamComponent _teamComponent;

        private void Awake()
        {
            _teamComponent = this.GetComponent<TeamComponent>();
        }

        public void DealDamage(GameObject target)
        {
            if (!target.TryGetComponent(out HealthComponent damageable)) return;
            if (!target.TryGetComponent(out TeamComponent teamComponent)) return;
            if (_teamComponent.Affiliation == teamComponent.Affiliation) return;
            
            damageable.TakeDamage(damage);
        }
    }
}