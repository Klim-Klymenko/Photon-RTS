using System.Collections.Generic;
using System.GameCycle;
using Fusion;
using GameEngine.Objects.Unit;
using UnityEngine;

namespace GameEngine.Features.Coloring
{
    internal sealed class ColoringComponent : ISpawnable
    {
        private readonly UnitService _unitService;

        internal ColoringComponent(UnitService unitService)
        {
            _unitService = unitService;
        }

        void ISpawnable.OnSpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            IReadOnlyList<GameObject> alliedUnits = _unitService.GetAlliedUnits();
            for (int i = 0; i < alliedUnits.Count; i++)
            {
                alliedUnits[i].GetComponentInChildren<Renderer>().material.color = Color.blue;
            }
            
            IReadOnlyList<GameObject> enemyUnits = _unitService.GetEnemyUnits();
            for (int i = 0; i < enemyUnits.Count; i++)
            {
                enemyUnits[i].GetComponentInChildren<Renderer>().material.color = Color.red;
            }
        }
    }
}