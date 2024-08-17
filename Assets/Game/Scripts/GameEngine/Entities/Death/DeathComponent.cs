using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class DeathComponent : NetworkBehaviour
    {
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent = this.GetComponent<HealthComponent>();
        }

        public override void Spawned()
        {
            _healthComponent.OnDied += this.OnDied;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _healthComponent.OnDied -= this.OnDied;
        }

        private void OnDied()
        {
            this.Runner.Despawn(this.Object);
        }
    }
}