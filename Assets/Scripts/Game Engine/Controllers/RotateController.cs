using Common.Components;
using Fusion;
using Fusion.Input;
using UnityEngine;

namespace GameEngine.Controllers
{
    [RequireComponent(typeof(RotateComponent))]
    public sealed class RotateController : NetworkBehaviour
    {
        [SerializeField]
        private RotateComponent _rotateComponent;

        [SerializeField]
        private NetworkInputFacade _input;

        private void OnValidate()
        {
            _rotateComponent = GetComponent<RotateComponent>();
        }

        public override void FixedUpdateNetwork()
        {
            _rotateComponent.Rotate(_input.MoveDirection, Runner.DeltaTime);
        }
    }
}