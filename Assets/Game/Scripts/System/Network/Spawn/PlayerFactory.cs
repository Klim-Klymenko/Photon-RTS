using Common.Creation;
using Fusion;
using JetBrains.Annotations;
using UnityEngine;

namespace System.Network.Spawn
{
    [UsedImplicitly]
    internal sealed class PlayerFactory : IFactory<NetworkObject, PlayerRef>
    {
        private readonly NetworkPrefabRef _playerPrefab;
        private readonly Vector3 _spawnPosition;
        private readonly Vector3 _spawnRotation;
        private readonly NetworkRunner _runner;

        internal PlayerFactory(NetworkPrefabRef playerPrefab, Vector3 spawnPosition, Vector3 spawnRotation, NetworkRunner runner)
        {
            _playerPrefab = playerPrefab;
            _spawnPosition = spawnPosition;
            _spawnRotation = spawnRotation;
            _runner = runner;
        }

        NetworkObject IFactory<NetworkObject, PlayerRef>.Create(PlayerRef playerRef)
        {
            return _runner.Spawn(_playerPrefab, _spawnPosition, Quaternion.Euler(_spawnRotation), playerRef);
        }
    }
}