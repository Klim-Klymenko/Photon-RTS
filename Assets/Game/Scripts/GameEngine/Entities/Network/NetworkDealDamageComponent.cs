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

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        public void RpcDealDamage(NetworkObject target)
        {
            _damageComponent.DealDamage(target.gameObject);
        }
    }
}