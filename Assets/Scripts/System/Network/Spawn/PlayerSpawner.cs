using System.Collections.Generic;
using System.GameCycle;
using Common.Creation;
using Fusion;
using JetBrains.Annotations;

namespace System.Network.Spawn
{
    [UsedImplicitly]
    internal sealed class PlayerSpawner : IPlayerJoinable, IPlayerLeaveable
    {
        private readonly Dictionary<PlayerRef, NetworkObject> _players = new();
        
        private readonly IFactory<NetworkObject, PlayerRef> _playerFactory;
        private readonly NetworkRunner _runner;

        internal PlayerSpawner(IFactory<NetworkObject, PlayerRef> playerFactory, NetworkRunner runner)
        {
            _playerFactory = playerFactory;
            _runner = runner;
        }

        void IPlayerJoinable.OnPlayerJoined(PlayerRef playerRef)
        {
            if (!_runner.IsServer) return;

            NetworkObject spawnedPlayer = _playerFactory.Create(playerRef);
            _players.Add(playerRef, spawnedPlayer);
        }

        void IPlayerLeaveable.OnPlayerLeft(PlayerRef playerRef)
        {
            NetworkObject networkPlayer = _players[playerRef];

            _players.Remove(playerRef);
            _runner.Despawn(networkPlayer);
        }
    }
}