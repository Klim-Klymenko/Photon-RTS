using System.GameCycle;
using System.Network.Input;
using Fusion;
using UnityEngine;

namespace GameEngine.Features.Formation
{
    internal sealed class FormationController : IFixedUpdatableNetwork
    {
        private readonly FormationComponent _formationComponent;
        private readonly NetworkInputFacade _input;
        private readonly Camera _camera;
        private readonly float _maxRayDistance;
        private readonly LayerMask _groundLayer;

        internal FormationController(FormationComponent formationComponent, NetworkInputFacade input, Camera camera, float maxRayDistance, LayerMask groundLayer)
        {
            _formationComponent = formationComponent;
            _input = input;
            _camera = camera;
            _maxRayDistance = maxRayDistance;
            _groundLayer = groundLayer;
        }

        void IFixedUpdatableNetwork.OnFixedUpdateNetwork(NetworkRunner runner, NetworkObject networkObject)
        {
            if (!_input.IsFormationStart) return;
          
            Ray ray = _camera.ScreenPointToRay(_input.MousePosition);
                
            if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _groundLayer))
                _formationComponent.Formate(networkObject, hit.point);
        }
    }
}