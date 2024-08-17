using System.Collections.Generic;
using System.GameCycle;
using Fusion;
using GameEngine.Features.Team;
using UnityEngine;

namespace GameEngine.Objects.Unit
{
    public sealed class UnitService : ISpawnable
    {
        private readonly List<GameObject> _alliedUnits = new();
        private readonly List<GameObject> _enemyUnits = new();

        void ISpawnable.OnSpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            TeamComponent[] sceneUnits = Object.FindObjectsByType<TeamComponent>(FindObjectsSortMode.None);
            TeamAffiliation teamAffiliation = networkObject.HasStateAuthority ? TeamAffiliation.Host : TeamAffiliation.Client;

            for (int i = 0; i < sceneUnits.Length; i++)
            {
                TeamComponent unit = sceneUnits[i];

                if (unit.Team == teamAffiliation)
                    _alliedUnits.Add(unit.gameObject);
                else
                    _enemyUnits.Add(unit.gameObject);
            }
        }

        public IReadOnlyList<GameObject> GetAlliedUnits()
        {
            return _alliedUnits;
        }

        public IReadOnlyList<GameObject> GetEnemyUnits()
        {
            return _enemyUnits;
        }
    }
}