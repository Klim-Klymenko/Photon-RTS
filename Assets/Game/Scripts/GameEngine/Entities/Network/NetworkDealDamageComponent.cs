using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [RequireComponent(typeof(DealDamageComponent))]
    public sealed class NetworkDealDamageComponent : NetworkBehaviour
    {
        private DealDamageComponent _damageComponent;

        private void Awake()
        {
            _damageComponent = this.GetComponent<DealDamageComponent>();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        public void RpcDealDamage(NetworkObject target)
        {
            if (target != null && this.Object.isActiveAndEnabled)
            {
                _damageComponent.DealDamage(target.gameObject);
            }
        }
    }
}