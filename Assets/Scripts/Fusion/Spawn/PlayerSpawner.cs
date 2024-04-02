using System.Collections.Generic;
using Common.Components;
using UnityEngine;

namespace Fusion.Startup
{
    internal sealed class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        [SerializeField]
        private PlayerFactory _playerFactory;
        
        private readonly Dictionary<PlayerRef, NetworkObject> _players = new();

        void IPlayerJoined.PlayerJoined(PlayerRef player)
        {
            if (!Runner.IsServer) return;

            NetworkObject spawnedPlayer = _playerFactory.Create(Runner, player);

            if (spawnedPlayer.TryGetComponent(out HealthComponent healthComponent))
                healthComponent.OnDied += () => Despawn(spawnedPlayer, player);
            
            _players.Add(player, spawnedPlayer);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef player)
        {
            if (!_players.TryGetValue(player, out NetworkObject spawnedPlayer)) return;
            
            Despawn(spawnedPlayer, player);
        }

        private void Despawn(NetworkObject spawnedPlayer, PlayerRef player)
        {
            Runner.Despawn(spawnedPlayer);
            _players.Remove(player);
        }
    }
}