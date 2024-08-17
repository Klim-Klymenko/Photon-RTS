using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class NetworkMovementAgent : NetworkBehaviour
    {
        [SerializeField]
        private MovementAgent _movementAgent;

        public override void FixedUpdateNetwork()
        {
            _movementAgent.OnFixedUpdate(this.Runner.DeltaTime);
        }
    }
}