using System.GameCycle;
using UnityEngine;
using System.Network.Input;

namespace GameEngine.Entities.Movement
{
    internal sealed class MovementController : IFixedUpdatable
    {
        private readonly CamComponent _camComponent;
        private readonly NetworkInputFacade _input;

        internal MovementController(CamComponent camComponent, NetworkInputFacade input)
        {
            _camComponent = camComponent;
            _input = input;
        }

        void IFixedUpdatable.OnFixedUpdate()
        {
            _camComponent.Move(_input.MoveDirection, Time.fixedDeltaTime);
        }
    }
}