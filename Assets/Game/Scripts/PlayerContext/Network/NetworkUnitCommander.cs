using Fusion;
using UnityEngine;

namespace Game.GameEngine.PlayerContext
{
    [RequireComponent(typeof(UnitCommander))]
    public sealed class NetworkUnitCommander : NetworkBehaviour
    {
        private UnitCommander _unitCommander;

        private void Awake()
        {
            _unitCommander = this.GetComponent<UnitCommander>();
        }

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        public void RpcMoveToPosition(Vector3 targetPosition)
        {
            _unitCommander.MoveToPosition(targetPosition);
        }
    }
}