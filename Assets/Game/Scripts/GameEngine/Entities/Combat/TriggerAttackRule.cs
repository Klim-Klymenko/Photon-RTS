using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(AttackComponent))]
    public sealed class TriggerAttackRule : MonoBehaviour
    {
        private AttackComponent _attackComponent;

        private void Awake()
        {
            _attackComponent = this.GetComponent<AttackComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _attackComponent.DealDamage(other.gameObject);
        }
    }
}