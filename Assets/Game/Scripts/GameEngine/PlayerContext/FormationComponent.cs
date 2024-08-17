// using System.Collections.Generic;
// using Fusion;
// using GameEngine.Objects.Unit;
// using UnityEngine;
//
// namespace GameEngine.Entities.Formation
// {
//     internal sealed class FormationComponent : ISpawnable
//     {
//         private MovementAgent[] _agents;
//         private NetworkObject[] _networkUnits;
//         
//         private readonly UnitService _unitService;
//         
//         internal FormationComponent(UnitService unitService)
//         {
//             _unitService = unitService;
//         }
//         
//         void ISpawnable.OnSpawned(NetworkRunner runner, NetworkObject networkObject)
//         {
//             IReadOnlyList<GameObject> alliedUnits = _unitService.GetAlliedUnits();
//             int unitsCount = alliedUnits.Count;
//             
//             _agents = new MovementAgent[unitsCount];
//             _networkUnits = new NetworkObject[unitsCount];
//             
//             for (int i = 0; i < unitsCount; i++)
//             {
//                 GameObject unit = alliedUnits[i];
//                 
//                 _agents[i] = unit.GetComponent<MovementAgent>();
//                 _networkUnits[i] = unit.GetComponent<NetworkObject>();
//             }
//         }
//         
//         
//         [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
//         public void RpcSetTargetPosition(Vector3 position)
//         {
//             this.SetTargetPosition(position);
//         }
//
//         internal void Formate(NetworkObject networkObject, Vector3 position)
//         {
//             if (networkObject.HasStateAuthority)
//             {
//                 for (int i = 0; i < _agents.Length; i++)
//                 {
//                     if (_agents[i] != null && _networkUnits[i].isActiveAndEnabled)
//                         _agents[i].SetTargetPosition(position);
//                 }
//                 
//                 return;
//             }
//             
//             for (int i = 0; i < _agents.Length; i++)
//             {
//                 if (_agents[i] != null && _networkUnits[i].isActiveAndEnabled)
//                     _agents[i].RpcSetTargetPosition(position);
//             }
//         }
//     }
// }