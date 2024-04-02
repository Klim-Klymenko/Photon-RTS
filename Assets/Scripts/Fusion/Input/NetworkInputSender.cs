using UnityEngine;

namespace Fusion.Input
{
    public sealed class NetworkInputSender : MonoBehaviour
    {
        [SerializeField]
        private LocalInputFacade _localInputFacade;
        
        public void SendInput(ref NetworkInput networkInput)
        {
            NetworkInputData inputData = new NetworkInputData
            {
                MoveDirection = _localInputFacade.GetDirection(),
                IsSpaceDown = _localInputFacade.GetSpaceDown()
            };
            
            networkInput.Set(inputData);
        }
    }
}