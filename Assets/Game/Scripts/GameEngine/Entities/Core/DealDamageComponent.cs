using Game.GameEngine.Common;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(TeamComponent))]
    public sealed class DealDamageComponent : MonoBehaviour
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
            Debug.Log("DEAL DAMAGE");
            
            if (!target.CompareTag(GameObjectTags.Unit)) return;
            if (!target.TryGetComponent(out HealthComponent damageable)) return;
            if (!target.TryGetComponent(out TeamComponent teamComponent)) return;
            if (_teamComponent.Affiliation == teamComponent.Affiliation) return;
            
            damageable.TakeDamage(damage);
        }
    }
}