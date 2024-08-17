// using UnityEngine;
// using Zenject;
//
// namespace Game.GameEngine.GameContext
// {
//     public sealed class CameraMover : ITickable
//     {
//         private readonly Transform _cameraTransform;
//         private readonly float _speed;
//         private readonly CameraInput _input;
//
//         public CameraMover(
//             Transform cameraTransform,
//             float moveSpeed,
//             CameraInput input
//         )
//         {
//             _cameraTransform = cameraTransform;
//             _speed = moveSpeed;
//             _input = input;
//         }
//
//         public void Tick()
//         {
//             _cameraTransform.position += _input.GetDirection() * (_speed * Time.deltaTime);
//         }
//     }
// }