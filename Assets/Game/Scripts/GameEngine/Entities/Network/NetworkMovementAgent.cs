using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(MovementAgent))]
    public sealed class NetworkMovementAgent : NetworkBehaviour
    {
        private MovementAgent _movementAgent;

        private void Awake()
        {
            _movementAgent = this.GetComponent<MovementAgent>();
        }

        public override void FixedUpdateNetwork()
        {
            _movementAgent.OnFixedUpdate(this.Runner.DeltaTime);
        }
    }
}