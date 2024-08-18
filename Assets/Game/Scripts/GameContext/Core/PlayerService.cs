using System;
using Game.GameEngine.Common;
using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class PlayerService : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] players;
        
        public GameObject GetPlayer(TeamAffiliation affiliation)
        {
            foreach (var player in this.players)
            {
                if (player.GetComponent<TeamComponent>().Affiliation == affiliation)
                {
                    return player;
                }
            }

            throw new Exception($"Player with team \"{affiliation}\" is not found!");
        }
    }
}