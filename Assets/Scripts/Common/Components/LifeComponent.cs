using Fusion;
using UnityEngine;

namespace Common.Components
{
    public sealed class LifeComponent : NetworkBehaviour
    {
        [SerializeField]
        private float _lifeTime;
        
        [Networked]
        private TickTimer LifeTimer { get; set; }

        public override void Spawned()
        {
            LifeTimer = TickTimer.CreateFromSeconds(Runner, _lifeTime);
        }

        public override void FixedUpdateNetwork()
        {
            if (!LifeTimer.Expired(Runner)) return;
                
            Runner.Despawn(Object);
        }
    }
}