using System;
using UnityEngine;

namespace Fusion.Startup
{
    [Serializable]
    public sealed class PlayerFactory
    {
        [SerializeField]
        private NetworkPrefabRef _playerPrefab;

        [SerializeField]
        private Vector3 _spawnPosition;
        
        public NetworkObject Create(NetworkRunner runner, PlayerRef playerRef)
        {
            return runner.Spawn(_playerPrefab, _spawnPosition, Quaternion.identity, playerRef);
        }
    }
}