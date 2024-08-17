using System.GameCycle;
using UnityEngine;
using System.Network.Input;

namespace GameEngine.Features.Movement
{
    internal sealed class MovementController : IFixedUpdatable
    {
        private readonly MovementComponent _movementComponent;
        private readonly NetworkInputFacade _input;

        internal MovementController(MovementComponent movementComponent, NetworkInputFacade input)
        {
            _movementComponent = movementComponent;
            _input = input;
        }

        void IFixedUpdatable.OnFixedUpdate()
        {
            _movementComponent.Move(_input.MoveDirection, Time.fixedDeltaTime);
        }
    }
}