// using System;
// using UnityEngine;
// using Zenject;
//
// namespace Game.GameEngine.GameContext
// {
//     public sealed class OrderInput : IInitializable, ITickable
//     {
//         private const float MAX_RAY_DISTANCE = 100;
//
//         public event Action<Vector3> OnClicked; 
//
//         private readonly Camera _camera;
//         private LayerMask _groundLayer;
//
//         public void Initialize()
//         {
//             _groundLayer = LayerMask.NameToLayer("Ground");
//         }
//
//         public void Tick()
//         {
//             if (!Input.GetMouseButtonDown(0))
//             {
//                 return;
//             }
//             
//             Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
//             if (!Physics.Raycast(ray, out RaycastHit hit, MAX_RAY_DISTANCE, _groundLayer))
//             {
//                 return;
//             }
//
//             this.OnClicked?.Invoke(hit.point);
//         }
//     }
// }