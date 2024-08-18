using System.Collections.Generic;
using Fusion;
using Game.GameEngine.Common;
using Game.GameEngine.GameContext;
using UnityEngine;

namespace System.Network.Spawn
{
    [RequireComponent(typeof(PlayerService))]
    public sealed class NetworkPlayerJoiner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        private readonly Dictionary<PlayerRef, NetworkObject> players = new();

        private PlayerService _playerService;

        private void Awake()
        {
            _playerService = this.GetComponent<PlayerService>();
        }

        public void PlayerJoined(PlayerRef playerRef)
        {
            if (playerRef.PlayerId == 1)
            {
                if (this.Runner.IsServer)
                {
                    GameObject playerGO = _playerService.GetPlayer(TeamAffiliation.Red);
                    this.GetComponent<PlayerProvider>().CurrentPlayer = playerGO;    
                }
            }

            if (playerRef.PlayerId == 2)
            {
                GameObject playerGO = _playerService.GetPlayer(TeamAffiliation.Blue);

                if (this.Runner.IsClient)
                {
                    this.GetComponent<PlayerProvider>().CurrentPlayer = playerGO;
                }

                if (this.Runner.IsServer)
                {
                    NetworkObject networkObject = playerGO.GetComponent<NetworkObject>();
                    networkObject.AssignInputAuthority(playerRef);
                    this.players.Add(playerRef, networkObject);
                }
            }
        }

      
        public void PlayerLeft(PlayerRef playerRef)
        {
            if (this.Runner.IsServer)
            {
                if (this.players.Remove(playerRef, out NetworkObject networkObject))
                {
                    networkObject.RemoveInputAuthority();
                }
            }
        }
    }
}
