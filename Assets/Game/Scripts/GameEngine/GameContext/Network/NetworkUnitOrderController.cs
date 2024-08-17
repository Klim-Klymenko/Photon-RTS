using Game.GameEngine.PlayerContext;
using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class NetworkUnitOrderController : MonoBehaviour
    {
        private OrderInput _input;
        private PlayerProvider _playerProvider;

        private void Awake()
        {
            _input = this.GetComponent<OrderInput>();
            _playerProvider = this.GetComponent<PlayerProvider>();
        }
        
        private void OnEnable()
        {
            _input.OnClicked += this.OnClicked;
        }

        private void OnDisable()
        {
            _input.OnClicked -= this.OnClicked;
        }

        private void OnClicked(Vector3 targetPosition)
        {
            NetworkUnitCommander unitCommander = _playerProvider.GetComponentOfCurrentPlayer<NetworkUnitCommander>();
            unitCommander.RpcMoveToPosition(targetPosition);
        }
    }
}