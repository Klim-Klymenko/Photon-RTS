using System.Collections.Generic;
using System.GameCycle;
using Fusion;
using GameEngine.Features.Relocation;
using GameEngine.Objects.Unit;
using UnityEngine;

namespace GameEngine.Features.Formation
{
    internal sealed class FormationComponent : ISpawnable
    {
        private RelocationComponent[] _agents;
        private NetworkObject[] _networkUnits;
        
        private readonly UnitService _unitService;
        
        internal FormationComponent(UnitService unitService)
        {
            _unitService = unitService;
        }
        
        void ISpawnable.OnSpawned(NetworkRunner runner, NetworkObject networkObject)
        {
            IReadOnlyList<GameObject> alliedUnits = _unitService.GetAlliedUnits();
            int unitsCount = alliedUnits.Count;
            
            _agents = new RelocationComponent[unitsCount];
            _networkUnits = new NetworkObject[unitsCount];
            
            for (int i = 0; i < unitsCount; i++)
            {
                GameObject unit = alliedUnits[i];
                
                _agents[i] = unit.GetComponent<RelocationComponent>();
                _networkUnits[i] = unit.GetComponent<NetworkObject>();
            }
        }

        internal void Formate(NetworkObject networkObject, Vector3 position)
        {
            if (networkObject.HasStateAuthority)
            {
                for (int i = 0; i < _agents.Length; i++)
                {
                    if (_agents[i] != null && _networkUnits[i].isActiveAndEnabled)
                        _agents[i].SetTargetPosition(position);
                }
                
                return;
            }
            
            for (int i = 0; i < _agents.Length; i++)
            {
                if (_agents[i] != null && _networkUnits[i].isActiveAndEnabled)
                    _agents[i].RpcSetTargetPosition(position);
            }
        }
    }
}