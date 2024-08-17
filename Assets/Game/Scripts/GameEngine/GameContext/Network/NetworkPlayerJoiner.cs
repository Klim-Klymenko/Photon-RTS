using System.Collections.Generic;
using Fusion;
using Game.GameEngine.GameContext;
using JetBrains.Annotations;
using UnityEngine;

namespace System.Network.Spawn
{
    [UsedImplicitly]
    public sealed class NetworkPlayerJoiner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {

        private readonly Dictionary<PlayerRef, NetworkObject> players = new();
        

        public void PlayerJoined(PlayerRef playerRef)
        {
            // NetworkRunner runner = this.Runner;
            // if (runner.IsServer)
            // {
            //     if (playerRef.IsMasterClient)
            //     {
            //         
            //     }
            //     else
            //     {
            //         
            //     }
            // }
            
            



         

            
            //
            // if (this.Runner.LocalPlayer == playerRef)
            // {
            //     this.GetComponent<PlayerProvider>().CurrentPlayer = 
            // }
        }

        public void PlayerLeft(PlayerRef playerRef)
        {
            if (this.players.Remove(playerRef, out NetworkObject networkObject))
            {
                this.Runner.Despawn(networkObject);
            }
        }
    }
}