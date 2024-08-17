using Fusion;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.PlayerContext
{
    public sealed class RpcUnitCommander : NetworkBehaviour, IUnitCommander
    {
        private IUnitCommander _unitCommander;
        
        [Inject]
        private void Construct(UnitStack stack)
        {
            _unitCommander = new UnitCommander(stack);
        }
        
        public void MoveToPosition(Vector3 targetPosition)
        {
            this.RpcMoveToPosition(targetPosition);
        }

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        private void RpcMoveToPosition(Vector3 targetPosition)
        {
            _unitCommander.MoveToPosition(targetPosition);
        }
    }
}