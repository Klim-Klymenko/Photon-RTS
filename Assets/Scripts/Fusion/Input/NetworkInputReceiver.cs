using UnityEngine;

namespace Fusion.Input
{
    public sealed class NetworkInputReceiver : NetworkBehaviour
    {
        [SerializeField]
        private NetworkInputFacade _inputFacade;
        
        public override void FixedUpdateNetwork()
        {
            if (!GetInput(out NetworkInputData inputData)) return;
            
            _inputFacade.SetInput(inputData);
        }
    }
}