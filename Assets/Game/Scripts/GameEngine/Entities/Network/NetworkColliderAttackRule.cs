using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(NetworkDealDamageComponent))]
    public sealed class NetworkColliderAttackRule : NetworkBehaviour
    {
        private NetworkDealDamageComponent _dealDamageComponent;

        private void Awake()
        {
            _dealDamageComponent = this.GetComponent<NetworkDealDamageComponent>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (this.Runner == null || !this.Runner.IsServer)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out NetworkObject networkObject))
            {
                _dealDamageComponent.RpcDealDamage(networkObject);
            }
        }
    }
}