using Common.Components;
using Fusion;
using Fusion.Input;
using UnityEngine;

namespace GameEngine.Controllers
{
    [RequireComponent(typeof(MoveComponent))]
    public sealed class MoveController : NetworkBehaviour
    {
        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField] 
        private NetworkInputFacade _input;

        private void OnValidate()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        public override void FixedUpdateNetwork()
        {
            _moveComponent.Move(_input.MoveDirection, Runner.DeltaTime);
        }
    }
}