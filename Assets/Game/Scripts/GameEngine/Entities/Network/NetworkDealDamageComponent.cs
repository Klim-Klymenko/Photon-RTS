using Fusion;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class NetworkDealDamageComponent : NetworkBehaviour
    {
        [SerializeField]
        private DealDamageComponent _damageComponent;

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        public void RpcDealDamage(NetworkObject target)
        {
            _damageComponent.DealDamage(target.gameObject);
        }
    }
}