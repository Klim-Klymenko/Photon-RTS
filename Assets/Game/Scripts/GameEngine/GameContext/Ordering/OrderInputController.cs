// using System;
// using Game.GameEngine.PlayerContext;
// using UnityEngine;
// using Zenject;
//
// namespace Game.GameEngine.GameContext
// {
//     public sealed class OrderInputController : IInitializable, IDisposable
//     {
//         private readonly OrderInput _input;
//         private readonly PlayerProvider _playerProvider;
//
//         public OrderInputController(OrderInput input, PlayerProvider playerProvider)
//         {
//             _input = input;
//             _playerProvider = playerProvider;
//         }
//
//         public void Initialize()
//         {
//             _input.OnClicked += this.OnClicked;
//         }
//
//         public void Dispose()
//         {
//             _input.OnClicked -= this.OnClicked;
//         }
//
//         private void OnClicked(Vector3 targetPosition)
//         {
//             IUnitCommander unitCommander = _playerProvider.GetServiceOfCurrentPlayer<IUnitCommander>();
//             unitCommander.MoveToPosition(targetPosition);
//         }
//     }
// }