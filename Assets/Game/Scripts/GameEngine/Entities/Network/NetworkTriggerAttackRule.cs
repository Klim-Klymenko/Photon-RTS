using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(NetworkDealDamageComponent))]
    public sealed class NetworkTriggerAttackRule : MonoBehaviour
    {
        private NetworkDealDamageComponent _dealDamageComponent;

        private void Awake()
        {
            _dealDamageComponent = this.GetComponent<NetworkDealDamageComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NetworkObject networkObject))
            {
                _dealDamageComponent.RpcDealDamage(networkObject);
            }
        }
    }
}