using Fusion;

namespace System.Network.Input
{
    public sealed class NetworkInputReceiver : NetworkBehaviour
    {
        private NetworkInputFacade _inputFacade;

        public void Construct(NetworkInputFacade inputFacade)
        {
            _inputFacade = inputFacade;
        }
        
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData inputData)) 
                _inputFacade.ReceiveInput(inputData);
        }
    }
}